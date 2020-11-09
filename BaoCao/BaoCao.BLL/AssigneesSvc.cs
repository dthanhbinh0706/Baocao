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

    public class AssigneesSvc : GenericSvc<AssigneesRep, Assignees>
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
        public override SingleRsp Update(Assignees m)
        {
            var res = new SingleRsp();

            var m1 = m.AssigneeId > 0 ? _rep.Read(m.AssigneeId) : _rep.Read(m.AssigneeName);
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
        public AssigneesSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get Assignee By ID -- 
        public object GetAssigneeById(int id)
        {

            var product = from p in _rep.Context.Assignees
                          where p.AssigneeId == id
                          select new
                          {
                              assigneeId = p.AssigneeId,
                              assigneeName = p.AssigneeName,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Get Community With Pagination --
        public object GetAllAssigneeWithPagination(int page, int size)
        {
            var products = from p in _rep.Context.Assignees
                           select new
                           {
                               assigneeId = p.AssigneeId,
                               assigneeName = p.AssigneeName,
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.assigneeId).Skip(offset).Take(size).ToList();
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


        #region -- Create Assignee --

        public SingleRsp CreateAssignee(AssigneesReq pro)
        {
            var res = new SingleRsp();
            Assignees product = new Assignees();

            product.AssigneeId = pro.AssigneeId;
            product.AssigneeName = pro.AssigneeName;

            res = _rep.CreateAssignee(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update Community --

        public SingleRsp UpdateAssignee(int id, AssigneesReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.AssigneeId.Equals(id));

            product.AssigneeId = pro.AssigneeId;
            product.AssigneeName = pro.AssigneeName;
            res = _rep.UpdateAssignee(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete Community  --
        public object DeleteAssignee(int id)
        {
            return _rep.DeleteAssignee(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchAssigneeWithPagination(string key, int page, int size)
        {
            return _rep.searchAssigneeWithPagination(key, page, size);
        }
        #endregion
    }
}
