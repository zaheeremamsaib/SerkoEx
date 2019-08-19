using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Serko.Interfaces;

namespace Serko.Services
{
    public class FileHandlingRepo : IFileHandling
    {

        public string CreateFile(HttpPostedFileBase file, String path, String data)
        {
            string result = "";

            try
            {
                string[] lines = new string[] { data };
                System.IO.File.WriteAllLines(@path, lines);
                result = "File successfully created";
            } catch (Exception ex)
            {
                result = "Error occured: " + ex.Message;
            }

            return result;
        }

        public string SaveFile(HttpPostedFileBase file, String path)
        {
            String result = "";
            try
            {
                file.SaveAs(path);
                result = "File successfully uploaded";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public Boolean ValidFile(string data)
        {
            Boolean result=true;

            try
            {
                XDocument document = XDocument.Parse(data);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
               result = false;
            }
            return result;
        }

        public void DeleteFile()
        {
            string app_path = HttpContext.Current.Request.PhysicalPath;
            string app_url = HttpContext.Current.Request.RawUrl;
            string s = app_path.Replace("\\", "/");
            s = s.Replace(app_url, "/Uploads/temp.xml");

            File.Delete(s);
          
        }
    }
}