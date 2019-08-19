using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Serko.Interfaces;
using Serko.Models;

namespace Serko.Services
{
    public class ExpenseRepo : IExpense
    {
      
        public Expense Get()
        {

            string fragxml = cleanData(getXMLtext(getFilePath()));

            TotalExpense tExpense = populateTotalExpense(fragxml);
            
            if (tExpense.Total > 0)
            {
                calcTotalexcl(tExpense);
            }

            return (tExpense);
        }

        public TotalExpense calcTotalexcl(TotalExpense tExpense)
        {

            tExpense.Gst = getGST();
            tExpense.GstAmount = (tExpense.Total * (tExpense.Gst / 100));
            tExpense.TotalExcl = (tExpense.Total - (tExpense.Total * (tExpense.Gst / 100)));

            return tExpense;
        }

        public string cleanData(String data)
        {
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection emailMatches = emailRegex.Matches(data);

            foreach (Match emailMatch in emailMatches)
            {
                data = data.Replace(emailMatch.Value.ToString(), "removed/");
            }

            data = data.Replace("@","");

            return data;
        }

        public string getFilePath()
        {
            string app_path = HttpContext.Current.Request.PhysicalPath;
            string app_url = HttpContext.Current.Request.RawUrl;
            string s = app_path.Replace("\\", "/");
            s = s.Replace(app_url, "/Uploads/temp.xml");

            return s;
        }

        public string getConfigFilePath()
        {
            string app_path = HttpContext.Current.Request.PhysicalPath;
            string app_url = HttpContext.Current.Request.RawUrl;
            string s = app_path.Replace("\\", "/");
            s = s.Replace(app_url, "/Config/GST.properties");

            return s;
        }

        public string getXMLtext(string filePath)
        {
            string fragxml = File.ReadAllText(filePath);
            fragxml = "<root>" + fragxml + "</root>";

            return (fragxml);
        }

        public TotalExpense populateTotalExpense(string fragxml)
        {
            TotalExpense tExpense = new TotalExpense();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fragxml);

            XmlNodeList totalTags = doc.GetElementsByTagName("total");

            if (totalTags.Count < 1)
            {
                tExpense.Total = 0;
            }
            else
            {
                tExpense.Total = float.Parse(totalTags[0].InnerText);
            }

            XmlNodeList cost_centerTags = doc.GetElementsByTagName("cost_centre");

            if (cost_centerTags.Count < 1)
            {
                tExpense.CostCentre = "UNKNOWN";
            }
            else
            {
                tExpense.CostCentre = cost_centerTags[0].InnerText;
            }

            XmlNodeList payment_methodTags = doc.GetElementsByTagName("payment_method");

            if (payment_methodTags.Count < 1)
            {
                tExpense.Payment_method = "";
            }
            else
            {
                tExpense.Payment_method = payment_methodTags[0].InnerText;
            }

            XmlNodeList vendorTags = doc.GetElementsByTagName("vendor");

            if (vendorTags.Count < 1)
            {
                tExpense.Vendor = "";
            }
            else
            {
                tExpense.Vendor = vendorTags[0].InnerText;
            }

            XmlNodeList descriptionTags = doc.GetElementsByTagName("description");

            if (descriptionTags.Count < 1)
            {
                tExpense.Description = "";
            }
            else
            {
                tExpense.Description = descriptionTags[0].InnerText;
            }

            XmlNodeList dateTags = doc.GetElementsByTagName("date");

            if (dateTags.Count < 1)
            {
                tExpense.Date = "";
            }
            else
            {
                tExpense.Date = dateTags[0].InnerText;
            }

            return tExpense;

        }

        public float getGST()
        {
            string tempGST = File.ReadAllText(getConfigFilePath());
            string GST = tempGST.Substring(tempGST.IndexOf("=") + 1, 2);

            return float.Parse(GST);
        }
    }
}