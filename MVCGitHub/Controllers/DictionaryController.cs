using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class DictionaryController : Controller

    {
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry 1", 1);

            ViewBag.message = "One item was added to the dictionary";

            return View("Index");
        }

        public ActionResult AddList()
        {
            for (int i = 2; i < 2002; i++)
            {
                myDictionary.Add(("New Entry" + i), i);
            }

            ViewBag.display = myDictionary;

            return View("Display");
        }

        public ActionResult Display()
        {
            ViewBag.display = myDictionary;

            return View();
        }

        public ActionResult Remove()
        {
            myDictionary.Remove("New Entry 1");

            ViewBag.message = "New Entry 1 was removed from the dictionary";

            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();

            ViewBag.message = "All items were cleared from the dictionary";

            return View("Index");
        }

        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myDictionary.ContainsValue(5))
            {
                ViewBag.search = "The value was found in ";
            }

            else
            {
                ViewBag.message = "The value was not found in ";
            }
            
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;

            ViewBag.message = ViewBag.message + ViewBag.stopwatch + " seconds";

            return View("Index");
        }
    }
}