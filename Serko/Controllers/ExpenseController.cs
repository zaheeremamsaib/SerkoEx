using Serko.Interfaces;
using Serko.Models;
using Serko.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Serko.Controllers
{
    public class ExpenseController : ApiController
    {

        private readonly IExpense expenseRepo;
        public ExpenseController()
        {
            expenseRepo = new ExpenseRepo() ;
        }

        //GET api/<controller>
        public Expense Get()
        {
            return expenseRepo.Get();
        }

        //GET api/<controller>
        public TotalExpense TotalExpense()
        {
            return (TotalExpense)expenseRepo.Get();
        }

     
    }
}