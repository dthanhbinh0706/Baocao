using BaoCao.Common.DAL;
using BaoCao.Common.Rsp;
using BaoCao.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BaoCao.DAL
{
    public class StatesRep : GenericRep<DataContext, States>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override States Read(int id)
        {
            var res = All.FirstOrDefault(p => p.StateId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.StateId == id);
            m = base.Delete(m); //TODO
            return m.StateId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion

        //=================================================================
        //=================================================================

        #region -- Create State --
        public SingleRsp CreateState(States od)
        {
            var res = new SingleRsp();
            using (var context = new DataContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.States.Add(od);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion
        //=================================================================
        //=================================================================

        #region -- Update State --
        public SingleRsp UpdateState(States od)
        {
            var res = new SingleRsp();
            using (var context = new DataContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.States.Update(od);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion
        //=================================================================
        //=================================================================
        #region -- Delete State --
        public bool DeleteState(int ordId)
        {
            DataContext db = new DataContext();
            States orders = db.States.FirstOrDefault(x => x.StateId == ordId);
            if (orders == null) return false;
            db.States.Remove(orders);
            db.SaveChangesAsync();
            return true;
        }
        #endregion

        //=================================================================
        //=================================================================

        #region -- Mst --
        public object searchStateWithPagination(string key, int page, int size)
        {
            List<object> res = new List<object>();
            var cmn = (SqlConnection)Context.Database.GetDbConnection();
            if (cmn.State == ConnectionState.Closed)
                cmn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmt = cmn.CreateCommand();
                cmt.CommandText = "getKeyWordSearchState";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@key", key);
                cmt.Parameters.AddWithValue("@page", page);
                cmt.Parameters.AddWithValue("@size", size);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            stateId = row["StateId"],
                            stateName = row["StateName"],
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }
        #endregion
    }
}
