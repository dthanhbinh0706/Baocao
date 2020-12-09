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

    public class AssigneeDepartmentsSvc : GenericSvc<AssigneeDepartmentsRep, AssigneeDepartments>
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
        public override SingleRsp Update(AssigneeDepartments m)
        {
            var res = new SingleRsp();

            var m1 = m.AssigneeDepartmentId > 0 ? _rep.Read(m.AssigneeDepartmentId) : _rep.Read(m.AssigneeDepartmentId);
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
        public AssigneeDepartmentsSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get AssigneeDepartment By ID -- 
        public object GetAssigneeDepartmentById(int id)
        {

            var product = from p in _rep.Context.AssigneeDepartments
                          where p.AssigneeDepartmentId == id
                          select new
                          {
                              assigneeDepartmentId = p.AssigneeDepartmentId,
                              assigneeId = p.AssigneeId,
                              departmentId = p.DepartmentId,
                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Create AssigneeDepartment --

        public SingleRsp CreateAssigneeDepartment(AssigneeDepartmentsReq pro)
        {
            var res = new SingleRsp();
            AssigneeDepartments product = new AssigneeDepartments();

            product.AssigneeDepartmentId = pro.AssigneeDepartmentId;
            product.AssigneeId = pro.AssigneeId;
            product.DepartmentId = pro.DepartmentId;

            res = _rep.CreateAssigneeDepartment(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update AssigneeDepartment --

        public SingleRsp UpdateAssigneeDepartment(int id, AssigneeDepartmentsReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.AssigneeDepartmentId.Equals(id));

            product.AssigneeDepartmentId = pro.AssigneeDepartmentId;
            product.AssigneeId = pro.AssigneeId;
            product.DepartmentId = pro.DepartmentId;
            res = _rep.UpdateAssigneeDepartment(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete AssigneeDepartment  --
        public object DeleteAssigneeDepartment(int id)
        {
            return _rep.DeleteAssigneeDepartment(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchAssigneeDepartmentWithPagination(string key, int page, int size)
        {
            return _rep.searchAssigneeDepartmentWithPagination(key, page, size);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- GetAllAssigneeDepartmentWithPagination --
        public object GetAllAssigneeDepartmentWithPagination(int page, int size)
        {
            var products = from at in _rep.Context.AssigneeDepartments
                           join a in _rep.Context.Assignees on at.AssigneeId equals a.AssigneeId
                           join s in _rep.Context.Departments on at.DepartmentId equals s.DepartmentId
                           select new
                           {
                               assigneeDepartmentId = at.AssigneeDepartmentId,
                               assigneeName = a.AssigneeName,
                               departmentName = s.DepartmentName
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.assigneeDepartmentId).Skip(offset).Take(size).ToList();
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
        #region -- GetAllAssignees --
        public object GetAllAssignees()
        {
            var products = from at in _rep.Context.Assignees
                           join a in _rep.Context.Assignees on at.AssigneeId equals a.AssigneeId
                           select new
                           {
                               assigneeId = a.AssigneeId,
                               assigneeName = a.AssigneeName
                           };

            var data = products.OrderBy(x => x.assigneeId).Distinct().ToList();
            var res = new
            {
                data = data

            };
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================
        #region -- GetAllDepartments --
        public object GetAllDepartments()
        {
            var products = from at in _rep.Context.Departments
                           join s in _rep.Context.Departments on at.DepartmentId equals s.DepartmentId
                           select new
                           {
                               departmentId = s.DepartmentId,
                               departmentName = s.DepartmentName,
                           };

            var data = products.OrderBy(x => x.departmentId).Distinct().ToList();
            var res = new
            {
                data = data

            };
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================
    }
}


