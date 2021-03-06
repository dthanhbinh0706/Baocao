﻿using System;
using System.Collections.Generic;
using System.Linq;
using BaoCao.Common.BLL;
using BaoCao.Common.Req;
using BaoCao.Common.Rsp;
using BaoCao.DAL.Models;
using BaoCao.DAL;



namespace BaoCao.BLL
{

    public class ReportsSvc : GenericSvc<ReportsRep, Reports>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public ReportsSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get Report By ID -- 
        public object GetReportById(int id)
        {

            var product = from p in _rep.Context.Reports
                          where p.StateId == id
                          select new
                          {
                              stateId = p.StateId,
                              total = p.Total,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Get  With Pagination --
        public object GetAllReportWithPagination(int page, int size)
        {
            var products = from p in _rep.Context.Reports
                           select new
                           {
                               stateId = p.StateId,
                               total = p.Total,
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.stateId).Skip(offset).Take(size).ToList();
            var res = new
            {
                data = data,
                total_record = total,
                total_page = totalpage,
                page = page,
                size = size
            };
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================
        #region -- GetA -- 
        public object GetA()
        {

            var product = from p in _rep.Context.Reports
                          join s in _rep.Context.States on p.StateId equals s.StateId
                          select new
                          {
                              name = s.StateName,
                              value = p.Total,

                          };
            return product;


        }
        #endregion
        //===========================================================
        //===========================================================
        #region -- GetEx -- 
        public object GetEx(int id)
        {

            var product = from at in _rep.Context.AssigneeTasks
                          join a in _rep.Context.Assignees on at.AssigneeId equals a.AssigneeId
                          join ad in _rep.Context.AssigneeDepartments on at.AssigneeId equals ad.AssigneeId
                          join d in _rep.Context.Departments on ad.DepartmentId equals d.DepartmentId
                          join t in _rep.Context.Tasks on at.TaskId equals t.TaskId
                          join s in _rep.Context.States on at.StateId equals s.StateId
                          where at.AssigneeId == id
                          select new
                          {
                              assigneeId = at.AssigneeId,
                              assigneeTaskId = at.AssigneeTaskId,
                              assigneeName = a.AssigneeName,
                              departmentName = d.DepartmentName,
                              taskName = t.TaskName,
                              schedule = at.Schedule
                              

                          };
            return product;


        }
        #endregion
        //===========================================================
        //===========================================================
        #region -- GetDistinctiveDate --
        public object GetDistinctiveDate()
        {
            return _rep.GetDistinctiveDate();
        }
        #endregion
        //===========================================================
        //===========================================================
        #region -- get Order With UserId --
        public object getAssigneeByState(int userid)
        {
            return _rep.getAssigneeByState(userid);
        }
        #endregion
        //===========================================================
        //===========================================================
        
    }
}
