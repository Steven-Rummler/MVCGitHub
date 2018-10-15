using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class QueueController : Controller
    {
        //VARIABLES
        static Queue<string> myQueue = new Queue<string>();
        static Queue<string> myRevisedQueue = new Queue<string>();
        public int iCount = 0;

        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            //ViewBag.FoundResponse = "";

            return View("Index");
        }

        public ActionResult AddOne()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.FoundResponse = "";

            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));

            ViewBag.MyQueue = myQueue;

            return View("Index");
        }

        public ActionResult AddMany()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.FoundResponse = "";

            myQueue.Clear();

            for (iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));

                ViewBag.MyQueue = myQueue;
            }

            return View("Index");
        }

        public ActionResult Delete()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.FoundResponse = "";

            foreach (string sQueue in myQueue)
            {
                if (sQueue == "New Entry 27")
                {
                    foreach (string sString in myQueue)
                    {
                        if (iCount + 1 == 27)
                        {
                            iCount++;
                        }
                        else
                        {
                            myRevisedQueue.Enqueue("New Entry " + (iCount + 1));

                            ViewBag.MyQueue = myRevisedQueue;

                            iCount++;
                        }
                    }
                }

                else
                {
                    ViewBag.FoundResponse = "Your search was not found.";
                }
            }

            return View("Index");
        }

        public ActionResult Clear()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.FoundResponse = "";

            myQueue.Clear();

            return View("Index");
        }

        public ActionResult Search()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.FoundResponse = "";

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //Searching for value in the queue
                if (myQueue.Contains("New Entry 27"))
                {
                    ViewBag.FoundResponse = "We found your search!";
                }

                else
                {
                    ViewBag.FoundResponse = "Your search was not found.";
                }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.FoundResponse += " " + ts;


            return View("Search");
        }

        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;

            return View("Index");
        }
    }
}