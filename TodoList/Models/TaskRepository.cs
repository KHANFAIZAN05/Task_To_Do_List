using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TodoList.Controllers
{
    public class TaskRepository
    {


        public bool CreateTask(TaskList taskList)
        {
            int ret = -9;
            try
            {
                SqlParameter[] sqlParameters =
                  {
                    new SqlParameter("@TaskName",taskList.TaskName),
                    new SqlParameter("@TaskStatus",taskList.TaskStatus)
                };
                ret = DBPROC.Sp_Insert("Sp_Insert", sqlParameters);
                if (ret > -9)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable FindTask(int Id)
        {
            int ret = -9;
            try
            {
                DataTable dt = DBPROC.GetDataTable("Select * from Task Where TaskId =" + Id + ";");
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteTask(int Id)
        {
            int ret = -9;
            try
            {
                ret = DBPROC.Get_ScalerInt("Delete from Task Where TaskId =" + Id + ";");
                if (ret > -9)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public DataTable ViewTasks()
        {
            DataTable dt = new DataTable();
            try
            {

                dt = DBPROC.GetDataTable("Select * from Task");
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                return dt;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool UpdateTask(TaskList _task)
        {
            int ret = -9;
            try
            {

                string SqlQuery = "Update Task Set TaskName = '" + _task.TaskName + "', TskStatus ='" + _task.TaskStatus + "' where TaskId ='" + _task.TaskId + "'; ";

                ret = DBPROC.Get_ScalerInt(SqlQuery);
                if (ret > -9)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
          
        }


    }
}