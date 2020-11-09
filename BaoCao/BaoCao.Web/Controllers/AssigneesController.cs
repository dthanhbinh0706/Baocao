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
    public class AssigneesController : ControllerBase
    {
        public AssigneesController()
        {
            _svc = new AssigneesSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetAssigneeById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetAssigneeById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllAssigneeWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllAssigneeWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateAssignee([FromBody]AssigneesReq req)
        {
            var res = _svc.CreateAssignee(req);

            return Ok(res);
        }

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateAssignee(int Id, [FromBody]AssigneesReq req)
        {
            var res = _svc.UpdateAssignee(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteAssignee(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteAssignee(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchAssigneeWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchAssigneeWithPagination(key, page, size);
            return Ok(res);
        }

        private readonly AssigneesSvc _svc;
    }
}
