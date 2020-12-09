using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BaoCao.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using BaoCao.Web.Pages;
    using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        public DepartmentsController()
        {
            _svc = new DepartmentsSvc();
        }



        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetDepartmentById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetDepartmentById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllDepartmentWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllDepartmentWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateDepartment([FromBody]DepartmentsReq req)
        {
            var res = _svc.CreateDepartment(req);

            return Ok(res);








        }




        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateDepartment(int Id, [FromBody]DepartmentsReq req)
        {
            var res = _svc.UpdateDepartment(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteDepartment(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteDepartment(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchDepartmentWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchDepartmentWithPagination(key, page, size);
            return Ok(res);
        }

        private readonly DepartmentsSvc _svc;
    }
}

