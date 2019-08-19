using Serko.Interfaces;
using Serko.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serko.Controllers
{
    public class UploadController : Controller
    {
        private IFileHandling fileHandlingRepo;
        private IExpense expenseRepo;

        public UploadController()
        {
            fileHandlingRepo = new FileHandlingRepo();
            expenseRepo = new ExpenseRepo();
        }

        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            string str = Request.Params["command"];
          
            if (str == "UploadFile")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string fileName = "temp.xml";
                        string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        
                        ViewBag.Message = fileHandlingRepo.SaveFile(file, path);
      
                    } 

                }
                catch (System.NullReferenceException)
                {
                    ViewBag.Message = "Please select a file";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "An error: occured: "+ ex.Message;
                    return View();
                }

            }
            else if (str == "UploadData")
            {
                try
                {
                    string data = @Request.Params["data"];

                    if ((data == null) || (data==""))
                    {
                        ViewBag.Message = "No Data Found";
                        return View();
                    }

                    data = expenseRepo.cleanData(data);
                    string fileName = "temp.xml";
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);

                    ViewBag.Message = fileHandlingRepo.CreateFile(file,path,data);

                }
                catch (NullReferenceException)
                {
                    ViewBag.Message = "No Data Found";
                    return View();
                }
                catch(Exception ex)
                {
                    ViewBag.Message = "An error occured: " + ex.Message;
                    return View();
                }
            }

            string tempData = expenseRepo.getXMLtext(expenseRepo.getFilePath());

            if (!fileHandlingRepo.ValidFile(tempData))
            {
                ViewBag.Message = "Malformed XML. Please check and upload data again.";
            }

            return View();
        }
    }
}