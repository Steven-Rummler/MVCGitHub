using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

/*********************************
 * Tanner Garrett
 * Stack Controller
 *********************************/

namespace MyGroupDataStrMVC.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;

            return View();
        }



        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));

            ViewBag.MyStack = myStack;

            return View("Index");
        }

        public ActionResult AddList()
        {
            myStack.Clear();

            for (int i = 1; i < 2001; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }

            ViewBag.MyStack = myStack;

            return View("Index");

        }

        public ActionResult Display()
        {
            if (myStack.Count == 0)
            {
                ViewBag.TheStack = "";
                ViewBag.Display = "Sorry, no values in stack, please add values and try again";
                return View();

            }
            else
            {
                ViewBag.Display = "Here is your stack:";
                ViewBag.TheStack = myStack;
                return View();
            }
        }

        public ActionResult Delete()
        {
            if (myStack.Count == 0)
            {
                ViewBag.TheStack = "";
                ViewBag.Display = "Sorry, no values in stack, please add values and try again";
                return View("Display");
            }
            else
            {
                myStack.Pop();
                ViewBag.MyStack = myStack;
                return View("Index");
            }


        }

        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = myStack;
            return View("Index");

        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myStack.Count > 0)
            {
                if (myStack.Contains("New Entry 10"))
                {
                    ViewBag.Search = "\"New Entry 10\" is found in the stack";
                }
                else
                {
                    ViewBag.Search = "\"New Entry 10\" is NOT found in the stack";
                }
            }
            else
            {
                ViewBag.MyStack = "Sorry, no values in stack, please add values and try again";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;


            ViewBag.MyStack = myStack;
            return View();

        }

    }
}