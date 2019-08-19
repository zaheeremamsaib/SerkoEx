using Serko.Interfaces;
using Serko.Models;
using Serko.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serko.Controllers
{
    public class TotalExpenseController : Controller
    {

        private IExpense expenseRepo;

        public TotalExpenseController()
        {
            expenseRepo = new ExpenseRepo();
        }


        // GET: Expenses
        public ActionResult Index()
        {
            return View("Index");
        }

        [HandleError(View = "Error")]
        // GET: TotalExpenses
        public ActionResult Display()
        {
            return View("Display");
        }

        public ActionResult Zaheer()
        {
            return View("Zaheer", (TotalExpense)expenseRepo.Get());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
