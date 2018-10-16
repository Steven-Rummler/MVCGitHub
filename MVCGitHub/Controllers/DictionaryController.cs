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

        static int counter = 1;

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + counter, counter);

            counter++;

            ViewBag.message = "One item was added to the dictionary";

            return View("Index");
        }

        public ActionResult AddList()
        {
            for (int i = 2; i < 2002; i++)
            {
                myDictionary.Add("New Entry " + counter, counter);
                counter++;
            }

            //ViewBag.display = myDictionary;

            ViewBag.message = "HUGE LIST ADDED";

            return View("Index");
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

            counter = 0;

            return View("Index");
        }

        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myDictionary.ContainsValue(5))
            {
                ViewBag.message = "The value was found in ";
            }

            else
            {
                ViewBag.message = "The value was not found in ";
            }
            
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.message += ts + " seconds";

            return View("Index");
        }
    }
}