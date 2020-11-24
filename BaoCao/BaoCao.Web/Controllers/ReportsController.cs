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
    public class ReportsController : ControllerBase
    {
        public ReportsController()
        {
            _svc = new ReportsSvc();
        }

        // RESTful API

        //Get Method: api/Products/5
        [HttpGet("{Id}")]
        public IActionResult GetReportById(int Id)
        {
            var res = new SingleRsp();
            var product = _svc.GetReportById(Id);
            res.Data = product;

            return Ok(res);
        }

        // Get Method: api/Products
        [HttpGet]
        public IActionResult GetAllReportWithPagination(int page, int size)
        {
            var res = new SingleRsp();
            var products = _svc.GetAllReportWithPagination(page, size);
            res.Data = products;

            return Ok(res);
        }
        [HttpGet("GetA")]
        public IActionResult GetA()
        {
            var res = new SingleRsp();
            var products = _svc.GetA();
            res.Data = products;
            return Ok(res);
        }

        [HttpGet("getAssigneeByState/{Id}")]
        public IActionResult getAssigneeByState(int Id)
        {
            var res = new SingleRsp();
            res.Data = _svc.getAssigneeByState(Id);
            return Ok(res);
        }

        [HttpGet("GetDistinctiveDate")]
        public IActionResult GetDistinctiveDate()
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDistinctiveDate();
            return Ok(res);
        }


        private readonly ReportsSvc _svc;
    }
}
