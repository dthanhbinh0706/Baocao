using System;
using System.Collections.Generic;
using System.Linq;
using BaoCao.Common.BLL;
using BaoCao.Common.Req;
using BaoCao.Common.Rsp;
using BaoCao.DAL.Models;
using BaoCao.DAL;



namespace BaoCao.BLL
{

    public class AssigneeTasksSvc : GenericSvc<AssigneeTasksRep, AssigneeTasks>
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

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(AssigneeTasks m)
        {
            var res = new SingleRsp();

            var m1 = m.AssigneeTaskId > 0 ? _rep.Read(m.AssigneeTaskId) : _rep.Read(m.TaskId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public AssigneeTasksSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get AssigneeTask By ID -- 
        public object GetAssigneeTaskById(int id)
        {

            var product = from p in _rep.Context.AssigneeTasks
                          where p.AssigneeTaskId == id
                          select new
                          {
                              assigneeTaskId =p.AssigneeTaskId,
                              assigneeId = p.AssigneeId,
                              taskId = p.TaskId,
                              stateId=p.StateId,
                              schedule = p.Schedule,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Create AssigneeTask --

        public SingleRsp CreateAssigneeTask(AssigneeTasksReq pro)
        {
            var res = new SingleRsp();
            AssigneeTasks product = new AssigneeTasks();

            product.AssigneeTaskId = pro.AssigneeTaskId;
            product.AssigneeId = pro.AssigneeId;
            product.TaskId = pro.TaskId;
            product.StateId = pro.StateId;
            product.Schedule = pro.Schedule;

            res = _rep.CreateAssigneeTask(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update AssigneeTask --

        public SingleRsp UpdateAssigneeTask(int id, AssigneeTasksReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.AssigneeTaskId.Equals(id));

            product.AssigneeTaskId = pro.AssigneeTaskId;
            product.AssigneeId = pro.AssigneeId;
            product.TaskId = pro.TaskId;
            product.StateId = pro.StateId;
            product.Schedule = pro.Schedule;
            res = _rep.UpdateAssigneeTask(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete AssigneeTask  --
        public object DeleteAssigneeTask(int id)
        {
            return _rep.DeleteAssigneeTask(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchAssigneeTaskWithPagination(string key, int page, int size)
        {
            return _rep.searchAssigneeTaskWithPagination(key, page, size);
        }
        #endregion
        //===========================================================
        //===========================================================


        #region -- GetAllAssigneeTaskWithPagination --
        public object GetAllAssigneeTaskWithPagination(int page, int size)
        {
            var products = from at in _rep.Context.AssigneeTasks
                           join a in _rep.Context.Assignees on at.AssigneeId equals a.AssigneeId
                           join s in _rep.Context.States on at.StateId equals s.StateId
                           join t in _rep.Context.Tasks on at.TaskId equals t.TaskId
                           select new
                           {
                               assigneeTaskId = at.AssigneeTaskId,
                               assigneeName = a.AssigneeName,
                                 stateName = s.StateName,
                                taskName = t.TaskName,
                                schedule = at.Schedule
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.assigneeTaskId).Skip(offset).Take(size).ToList();
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


    }
}
