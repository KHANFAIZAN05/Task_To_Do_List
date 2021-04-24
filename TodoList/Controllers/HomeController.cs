using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        TaskRepository tr;
        List<TaskList> lstTask = new List<TaskList>();
        public HomeController()
        {
            tr = new TaskRepository();
        }

        public ActionResult Index()
        {
            try
            {
                foreach (DataRow dr in tr.ViewTasks().Rows)
                {
                    TaskList Task = new TaskList();
                    Task.TaskId = Convert.ToInt32(dr["TaskId"]);
                    Task.TaskName = dr["TaskName"].ToString();
                    Task.TaskStatus = dr["TskStatus"].ToString();
                    lstTask.Add(Task);


                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(lstTask);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                if (tr.CreateTask(taskList))
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {

            foreach (DataRow dr in tr.FindTask(Id).Rows)
            {
                TaskList SingleTask = new TaskList();
                SingleTask.TaskId = Convert.ToInt32(dr["TaskId"]);
                SingleTask.TaskName = dr["TaskName"].ToString();
                SingleTask.TaskStatus = dr["TskStatus"].ToString();
                return View(SingleTask);


            }
            return View();
        }


        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                if (tr.DeleteTask(Id))
                {
                    return this.RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }


        public ActionResult Edit(int Id)
        {
            foreach (DataRow dr in tr.FindTask(Id).Rows)
            {
                TaskList SingleTask = new TaskList();
                SingleTask.TaskId = Convert.ToInt32(dr["TaskId"]);
                SingleTask.TaskName = dr["TaskName"].ToString();
                SingleTask.TaskStatus = dr["TskStatus"].ToString();
                return View(SingleTask);


            }
            return View();

        }



        [HttpPost]
        public ActionResult Edit(TaskList taskList)
        {
            try
            {
                if (tr.UpdateTask(taskList))
                {
                    return this.RedirectToAction("Index");
                }
                return View(taskList);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}