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
    public class StatesController : ControllerBase
    {
        public StatesController()
        {
            _svc = new StatesSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetStateById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetStateById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllStateWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllStateWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }

        // Post Method: api/Products
        [HttpPost]
        public IActionResult CreateState([FromBody]StatesReq req)
        {
            var res = _svc.CreateState(req);

            return Ok(res);
        }

        // Put Method: api/Products/5
        [HttpPut("{Id}")]
        public IActionResult UpdateState(int Id, [FromBody]StatesReq req)
        {
            var res = _svc.UpdateState(Id, req);

            return Ok(res);
        }

        // Delete Method: api/Products/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteState(int Id)
        {
            var res = new SingleRsp();
            var del = _svc.DeleteState(Id);
            res.Data = del;

            return Ok(res);
        }

        // Search Product
        [HttpGet("search")]
        public IActionResult searchStateWithPagination(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.searchStateWithPagination(key, page, size);
            return Ok(res);
        }

        private readonly StatesSvc _svc;
    }
}
