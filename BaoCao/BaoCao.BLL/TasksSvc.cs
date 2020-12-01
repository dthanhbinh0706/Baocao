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

    public class TasksSvc : GenericSvc<TasksRep, Tasks>
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
        public override SingleRsp Update(Tasks m)
        {
            var res = new SingleRsp();

            var m1 = m.TaskId > 0 ? _rep.Read(m.TaskId) : _rep.Read(m.TaskName);
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
        public TasksSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get Task By ID -- 
        public object GetTaskById(int id)
        {

            var product = from p in _rep.Context.Tasks
                          where p.TaskId == id
                          select new
                          {
                              taskId = p.TaskId,
                              taskName = p.TaskName,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Get Community With Pagination --
        public object GetAllTaskWithPagination(int page, int size)
        {
            var products = from p in _rep.Context.Tasks
                           select new
                           {
                               taskId = p.TaskId,
                               taskName = p.TaskName,
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.taskId).Skip(offset).Take(size).ToList();
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


        #region -- Create Task --

        public SingleRsp CreateTask(TasksReq pro)
        {
            var res = new SingleRsp();
            Tasks product = new Tasks();

            product.TaskId = pro.TaskId;
            product.TaskName = pro.TaskName;

            res = _rep.CreateTask(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update Community --

        public SingleRsp UpdateTask(int id, TasksReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.TaskId.Equals(id));

            product.TaskId = pro.TaskId;
            product.TaskName = pro.TaskName;
            res = _rep.UpdateTask(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete Community  --
        public object DeleteTask(int id)
        {
            return _rep.DeleteTask(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchTaskWithPagination(string key, int page, int size)
        {
            return _rep.searchTaskWithPagination(key, page, size);
        }
        #endregion




    }
}
