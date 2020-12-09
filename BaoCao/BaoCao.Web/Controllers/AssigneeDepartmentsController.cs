using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoCao.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class AssigneeDepartmentsController : ControllerBase
    {
        public AssigneeDepartmentsController()
        {
            _svc = new AssigneeDepartmentsSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetAssigneeDepartmentById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetAssigneeDepartmentById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateAssigneeDepartment([FromBody]AssigneeDepartmentsReq req)
        {
            var res = _svc.CreateAssigneeDepartment(req);

            return Ok(res);
        }

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateAssigneeDepartment(int Id, [FromBody]AssigneeDepartmentsReq req)
        {
            var res = _svc.UpdateAssigneeDepartment(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteAssigneeDepartment(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteAssigneeDepartment(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchAssigneeDepartmentWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchAssigneeDepartmentWithPagination(key, page, size);
            return Ok(res);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllAssigneeDepartmentWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetAllAssigneeDepartmentWithPagination(page, size);
            return Ok(res);
        }

        [HttpGet("GetAllAssignees")]
        public IActionResult GetAllAssignees()
        {
            var res = new SingleRsp();
            res.Data = _svc.GetAllAssignees();
            return Ok(res);
        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllStates()
        {
            var res = new SingleRsp();
            res.Data = _svc.GetAllDepartments();
            return Ok(res);
        }


        private readonly AssigneeDepartmentsSvc _svc;
    }
}


