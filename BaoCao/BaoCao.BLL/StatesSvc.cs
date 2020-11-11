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

    public class StatesSvc : GenericSvc<StatesRep, States>
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
        public override SingleRsp Update(States m)
        {
            var res = new SingleRsp();

            var m1 = m.StateId > 0 ? _rep.Read(m.StateId) : _rep.Read(m.StateName);
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
        public StatesSvc() { }


        #endregion
        //===========================================================
        //===========================================================

        #region -- Get State By ID -- 
        public object GetStateById(int id)
        {

            var product = from p in _rep.Context.States
                          where p.StateId == id
                          select new
                          {
                              stateId = p.StateId,
                              stateName = p.StateName,

                          };
            return product;
        }
        # endregion
        //===========================================================
        //===========================================================

        #region -- Get Community With Pagination --
        public object GetAllStateWithPagination(int page, int size)
        {
            var products = from p in _rep.Context.States
                           select new
                           {
                               stateId = p.StateId,
                               stateName = p.StateName,
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


        #region -- Create State --

        public SingleRsp CreateState(StatesReq pro)
        {
            var res = new SingleRsp();
            States product = new States();

            product.StateId = pro.StateId;
            product.StateName = pro.StateName;

            res = _rep.CreateState(product);
            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Update Community --

        public SingleRsp UpdateState(int id, StatesReq pro)
        {
            var res = new SingleRsp();

            var product = All.FirstOrDefault(x => x.StateId.Equals(id));

            product.StateId = pro.StateId;
            product.StateName = pro.StateName;
            res = _rep.UpdateState(product);

            return res;
        }
        #endregion
        //===========================================================
        //===========================================================

        #region -- Delete Community  --
        public object DeleteState(int id)
        {
            return _rep.DeleteState(id);
        }
        #endregion
        //===========================================================
        //===========================================================

        #region --Searh Product--
        public object searchStateWithPagination(string key, int page, int size)
        {
            return _rep.searchStateWithPagination(key, page, size);
        }
        #endregion
    }
}
