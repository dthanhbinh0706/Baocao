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
    public class ReportsRep : GenericRep<DataContext, Reports>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Reports Read(int id)
        {
            var res = All.FirstOrDefault(p => p.StateId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion

        #region -- getAssigneeByState--
        public object getAssigneeByState(int userid)
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
                cmt.CommandText = "GetTotalFor";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@userid", userid);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                       
                        res.Add(row["Total"]);
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

        #region -- GetDistinctiveDate--
        public object GetDistinctiveDate()
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
                cmt.CommandText = "GetDistinctiveDate";
                cmt.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        res.Add(row["schedule"]);
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
