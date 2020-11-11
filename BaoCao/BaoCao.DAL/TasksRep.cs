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
    public class TasksRep : GenericRep<DataContext, Tasks>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Tasks Read(int id)
        {
            var res = All.FirstOrDefault(p => p.TaskId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.TaskId == id);
            m = base.Delete(m); //TODO
            return m.TaskId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion

        //=================================================================
        //=================================================================

        #region -- Create Task --
        public SingleRsp CreateTask(Tasks od)
        {
            var res = new SingleRsp();
            using (var context = new DataContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tasks.Add(od);
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

        #region -- Update Task --
        public SingleRsp UpdateTask(Tasks od)
        {
            var res = new SingleRsp();
            using (var context = new DataContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tasks.Update(od);
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
        #region -- Delete Task --
        public bool DeleteTask(int ordId)
        {
            DataContext db = new DataContext();
            Tasks orders = db.Tasks.FirstOrDefault(x => x.TaskId == ordId);
            if (orders == null) return false;
            db.Tasks.Remove(orders);
            db.SaveChangesAsync();
            return true;
        }
        #endregion

        //=================================================================
        //=================================================================

        #region -- Mst --
        public object searchTaskWithPagination(string key, int page, int size)
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
                cmt.CommandText = "getKeyWordSearchTask";
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
                            taskId = row["TaskId"],
                            taskName = row["TaskName"],
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
