﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InternalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessOrderDetailsController : ControllerBase
    {
        private readonly MSIT44Context _context;

        public BusinessOrderDetailsController(MSIT44Context context)
        {
            _context = context;
        }





        //自己寫的
        // GET: api/BusinessOrderDetails/25/1
        [HttpGet("{ordid}/{oplid}")]
        public async Task<ActionResult<dynamic>> GetOdId(int ordid, int oplid)
        {
            var q = from od in _context.BusinessOrderDetails
                    where od.OrderId == ordid && od.OptionalId == oplid
                    select od.OdId;
            return await q.SingleOrDefaultAsync();
        }




        //自己寫的
        // PUT: api/BusinessOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{ordid}/{oplid}")]
        public async Task<IActionResult> PutOrderDetail(int ordid ,int oplid, BusinessOrderDetail businessOrderDetail)
        {


            var data = _context.BusinessOrderDetails
                .Where(od => od.OrderId == ordid).ToList();

            foreach (var item in data)
            {
                item.OptionalId = 2;
                _context.BusinessOrderDetails.Update(item);
            }
            await _context.SaveChangesAsync();


            //if (id != businessOrderDetail.OdId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(businessOrderDetail).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BusinessOrderDetailExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }













    // GET: api/BusinessOrderDetails
    [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessOrderDetail>>> GetBusinessOrderDetails()
        {
            return await _context.BusinessOrderDetails.ToListAsync();
        }

        // GET: api/BusinessOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessOrderDetail>> GetBusinessOrderDetail(int id)
        {
            var businessOrderDetail = await _context.BusinessOrderDetails.FindAsync(id);

            if (businessOrderDetail == null)
            {
                return NotFound();
            }

            return businessOrderDetail;
        }

        // PUT: api/BusinessOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessOrderDetail(int id, BusinessOrderDetail businessOrderDetail)
        {
            if (id != businessOrderDetail.OdId)
            {
                return BadRequest();
            }

            _context.Entry(businessOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessOrderDetailExists(id))
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

        // POST: api/BusinessOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessOrderDetail>> PostBusinessOrderDetail(BusinessOrderDetail businessOrderDetail)
        {
            _context.BusinessOrderDetails.Add(businessOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessOrderDetail", new { id = businessOrderDetail.OdId }, businessOrderDetail);
        }

        // DELETE: api/BusinessOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessOrderDetail(int id)
        {
            var businessOrderDetail = await _context.BusinessOrderDetails.FindAsync(id);
            if (businessOrderDetail == null)
            {
                return NotFound();
            }

            _context.BusinessOrderDetails.Remove(businessOrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessOrderDetailExists(int id)
        {
            return _context.BusinessOrderDetails.Any(e => e.OdId == id);
        }
    }
}
