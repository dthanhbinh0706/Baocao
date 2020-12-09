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

    public class DepartmentsSvc : GenericSvc<DepartmentsRep, Departments>
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
        public override SingleRsp Update(Departments m)
        {
            var res = new SingleRsp();

            var m1 = m.DepartmentId > 0 ? _rep.Read(m.DepartmentId) : _rep.Read(m.DepartmentName);
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
        public DepartmentsSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get Department By ID -- 
        public object GetDepartmentById(int id)
        {

            var product = from p in _rep.Context.Departments
                          where p.DepartmentId == id
                          select new
                          {
                              DepartmentId = p.DepartmentId,
                              DepartmentName = p.DepartmentName,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Get Community With Pagination --
        public object GetAllDepartmentWithPagination(int page, int size)
        {
            var products = from p in _rep.Context.Departments
                           select new
                           {
                               DepartmentId = p.DepartmentId,
                               DepartmentName = p.DepartmentName,
                           };

            // pagination
            var offset = (page - 1) * size;
            var total = products.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = products.OrderBy(x => x.DepartmentId).Skip(offset).Take(size).ToList();
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


        #region -- Create Department --

        public SingleRsp CreateDepartment(DepartmentsReq pro)
        {
            var res = new SingleRsp();
            Departments product = new Departments();

            product.DepartmentId = pro.DepartmentId;
            product.DepartmentName = pro.DepartmentName;

            res = _rep.CreateDepartment(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update Community --

        public SingleRsp UpdateDepartment(int id, DepartmentsReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.DepartmentId.Equals(id));

            product.DepartmentId = pro.DepartmentId;
            product.DepartmentName = pro.DepartmentName;
            res = _rep.UpdateDepartment(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete Community  --
        public object DeleteDepartment(int id)
        {
            return _rep.DeleteDepartment(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchDepartmentWithPagination(string key, int page, int size)
        {
            return _rep.searchDepartmentWithPagination(key, page, size);
        }
        #endregion




    }
}
