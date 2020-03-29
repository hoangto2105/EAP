using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Lab1WebAPI.Models;

namespace Lab1WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        // Dịch vụ hiển thị danh sách
        // Task thì luôn đi với kiểu Generic IActionResult, và luôn đi với 'async'
        //'async' thì luôn return về Ok.
        //Repository chính là class Repository trong thư mục Models.
        [HttpGet]
        public async Task<IActionResult> GetStaffs()
        {
            //List<Staff> list = Repository.staffs.ToList();
            return Ok(Repository.staffs);
        }


        //Dịch vụ tìm kiếm 
        // Trong WCF bắt buộc phải ghi [HttpGet("Search/{keyword}")]. Chứ ở đây bỏ cũng được.
        [HttpGet("Search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var result = Repository.staffs.Where(
                    s => s.Name.ToUpper().Equals(keyword) || s.Name.ToLower().Equals(keyword));
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        //Dịch vụ thêm mới
        public async Task<IActionResult> PostStaff(Staff newStaff)
        {
            try
            {
                Repository.staffs.Add(newStaff);
                return Ok(newStaff);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}