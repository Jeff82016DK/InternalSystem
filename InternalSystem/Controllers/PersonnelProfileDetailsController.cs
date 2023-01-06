﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalSystem.Models;

namespace InternalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelProfileDetailsController : ControllerBase
    {
        private readonly MSIT44Context _context;

        public PersonnelProfileDetailsController(MSIT44Context context)
        {
            _context = context;
        }

        // GET: api/PersonnelProfileDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonnelProfileDetail>>> GetPersonnelProfileDetails()
        {
            return await _context.PersonnelProfileDetails.ToListAsync();
        }

        // GET: api/PersonnelProfileDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonnelProfileDetail>> GetPersonnelProfileDetail(int id)
        {
            var personnelProfileDetail = await _context.PersonnelProfileDetails.FindAsync(id);

            if (personnelProfileDetail == null)
            {
                return NotFound();
            }

            return personnelProfileDetail;
        }

        //api/PersonnelProfileDetails/ss/2023001
        [HttpGet("ss{id}")]
        public async Task<ActionResult<dynamic>> SearchGetPersonnelProfileDetail(string id)
        {

            var SearchProfileDetail = from o in _context.PersonnelProfileDetails
                                      where o.EmployeeNumber == id
                                      join c in _context.PersonnelCityLists on o.CityId equals c.CityId
                                      join p in _context.PersonnelPositions on o.PositionId equals p.PositionId
                                      join d in _context.PersonnelDepartmentLists on o.DepartmentId equals d.DepId
                                      join r in _context.PersonnelRanks on o.RankId equals r.RankId
                                      select new
                                      {
                                          CityId = o.CityId,
                                          CityName = c.CityName,
                                          PositionId = o.PositionId,
                                          PositionName = p.PositionName,
                                          DepartmentId = o.DepartmentId,
                                          DepartmentId2 = o.DepartmentId2,
                                          DepName = d.DepName,
                                          RankId = o.RankId,
                                          Rank = r.Rank,
                                          EmployeeName = o.EmployeeName,
                                          EmployeeNumber = o.EmployeeNumber,
                                          HomePhone = o.HomePhone,
                                          Sex = o.Sex,
                                          IsMarried = o.IsMarried,
                                          IdentiyId = o.IdentiyId,
                                          Email = o.Email,
                                          Birthday = o.Birthday.ToString("yyyy-MM-dd"),
                                          PhoneNumber = o.PhoneNumber,
                                          Address = o.Address,
                                          DutyStatus = o.DutyStatus,
                                          Country = o.Country,
                                          EmergencyNumber = o.EmergencyNumber,
                                          EmergencyPerson = o.EmergencyPerson,
                                          EmergencyRelation = o.EmergencyRelation,
                                          EntryDate = o.EntryDate.ToString("yyyy-MM-dd"),
                                          Acount = o.Acount,
                                          Password = o.Password,
                                          Terminationdate = o.Terminationdate

                                      };

            if (SearchProfileDetail == null)
            {
                return NotFound();
            }

            return await SearchProfileDetail.ToListAsync();
        }

        //api/PersonnelProfileDetails/Name/name
        [HttpGet("ss/Name{name}")]
        public async Task<ActionResult<dynamic>> SearchNameGetPersonnelProfileDetail(string name)
        {

            var SearchNameProfileDetail = from o in _context.PersonnelProfileDetails
                                          where o.EmployeeName == name
                                          join c in _context.PersonnelCityLists on o.CityId equals c.CityId
                                          join p in _context.PersonnelPositions on o.PositionId equals p.PositionId
                                          join d in _context.PersonnelDepartmentLists on o.DepartmentId equals d.DepId
                                          join r in _context.PersonnelRanks on o.RankId equals r.RankId
                                          select new
                                          {
                                              CityId = o.CityId,
                                              CityName = c.CityName,
                                              PositionId = o.PositionId,
                                              PositionName = p.PositionName,
                                              DepartmentId = o.DepartmentId,
                                              DepartmentId2 = o.DepartmentId2,
                                              DepName = d.DepName,
                                              RankId = o.RankId,
                                              Rank = r.Rank,
                                              EmployeeName = o.EmployeeName,
                                              EmployeeNumber = o.EmployeeNumber,
                                              HomePhone = o.HomePhone,
                                              Sex = o.Sex,
                                              IsMarried = o.IsMarried,
                                              IdentiyId = o.IdentiyId,
                                              Email = o.Email,
                                              Birthday = o.Birthday.ToString("yyyy-MM-dd"),
                                              PhoneNumber = o.PhoneNumber,
                                              Address = o.Address,
                                              DutyStatus = o.DutyStatus,
                                              Country = o.Country,
                                              EmergencyNumber = o.EmergencyNumber,
                                              EmergencyPerson = o.EmergencyPerson,
                                              EmergencyRelation = o.EmergencyRelation,
                                              EntryDate = o.EntryDate.ToString("yyyy-MM-dd"),
                                              Acount = o.Acount,
                                              Password = o.Password,
                                              Terminationdate = o.Terminationdate

                                          };

            if (SearchNameProfileDetail == null)
            {
                return NotFound();
            }

            return await SearchNameProfileDetail.ToListAsync();
        }
        // PUT: api/PersonnelProfileDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnelProfileDetail(int id, PersonnelProfileDetail personnelProfileDetail)
        {
            if (id != personnelProfileDetail.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(personnelProfileDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelProfileDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonnelProfileDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonnelProfileDetail>> PostPersonnelProfileDetail(PersonnelProfileDetail personnelProfileDetail)
        {
            _context.PersonnelProfileDetails.Add(personnelProfileDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonnelProfileDetail", new { id = personnelProfileDetail.EmployeeId }, personnelProfileDetail);
        }

        // DELETE: api/PersonnelProfileDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnelProfileDetail(int id)
        {
            var personnelProfileDetail = await _context.PersonnelProfileDetails.FindAsync(id);
            if (personnelProfileDetail == null)
            {
                return NotFound();
            }

            _context.PersonnelProfileDetails.Remove(personnelProfileDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonnelProfileDetailExists(int id)
        {
            return _context.PersonnelProfileDetails.Any(e => e.EmployeeId == id);
        }
    }
}
