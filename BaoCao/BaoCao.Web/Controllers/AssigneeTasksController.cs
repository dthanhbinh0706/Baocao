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
    public class AssigneeTasksController : ControllerBase
    {
        public AssigneeTasksController()
        {
            _svc = new AssigneeTasksSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetAssigneeTaskById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetAssigneeTaskById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateAssigneeTask([FromBody]AssigneeTasksReq req)
        {
            var res = _svc.CreateAssigneeTask(req);

            return Ok(res);
        }

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateAssigneeTask(int Id, [FromBody]AssigneeTasksReq req)
        {
            var res = _svc.UpdateAssigneeTask(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteAssigneeTask(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteAssigneeTask(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchAssigneeTaskWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchAssigneeTaskWithPagination(key, page, size);
            return Ok(res);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllAssigneeTaskWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetAllAssigneeTaskWithPagination(page, size);
            return Ok(res);
        }

        private readonly AssigneeTasksSvc _svc;
    }
}

