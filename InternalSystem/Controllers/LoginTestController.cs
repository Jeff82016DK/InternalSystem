﻿using InternalSystem.Dotos;
using InternalSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace InternalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous] //僅開放登入頁面不需驗證
    public class LoginTestController : ControllerBase
    {
        private readonly MSIT44Context _context;
        public LoginTestController(MSIT44Context context) 
        {
            _context = context;
        }

        // api/LoginTest
        [HttpPost]
        public string login(LoginPost value)
        {
            var user = (from a in _context.PersonnelProfileDetails //找員工資料表
                        where a.Acount == value.Account  //帳號
                        && a.Password == value.Password  //密碼
                        select a).SingleOrDefault();  //帳號唯一值

            //這邊不null判斷了，直接報錯
            if (user == null)
            {
                return "帳號密碼錯誤";
            }
            else
            { //寫驗證
                var claims = new List<Claim>
                {
                    //登入成功獲取使用者資訊(似乎只能為strimg)
                    new Claim(ClaimTypes.Name, user.IdentiyId),  //ID
                    new Claim("FullName", user.EmployeeName),  //使用者名字
                    //new Claim(ClaimTypes.Role, "select")  //權限
                };
                //建構
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //跟他說要用cookie驗證，若執行到這一行，表示使用者已登入
                //SignIn
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return "使用者已登入";
            }
        }


        //登出
        [HttpDelete]
        public string logout()
        {
            //SignOut 使用cookie的資訊登出
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return "已登出";
        }
        //未登入
        [HttpGet("NoLogin")]
        public string noLogin()
        {
            return "未登入";
        }
        /*//沒權限
        [HttpGet("NoAccess")]
        public string noAccess()
        {
            return "沒權限啦";
        }
        */
    }
}
