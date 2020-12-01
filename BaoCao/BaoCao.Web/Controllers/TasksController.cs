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
    public class TasksController : ControllerBase
    {
        public TasksController()
        {
            _svc = new TasksSvc();
        }

        

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetTaskById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetTaskById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllTaskWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllTaskWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateTask([FromBody]TasksReq req)
        {
            var res = _svc.CreateTask(req);

                return Ok(res);
         
            

            
            
                
           
            
        }


        

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateTask(int Id, [FromBody]TasksReq req)
        {
            var res = _svc.UpdateTask(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteTask(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteTask(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchTaskWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchTaskWithPagination(key, page, size);
            return Ok(res);
        }

        private readonly TasksSvc _svc;
    }
}
