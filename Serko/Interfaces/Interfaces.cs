using Serko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Serko.Interfaces
{
    interface IExpense
    {
        Expense Get();
        string cleanData(String data);
        string getFilePath();
        string getXMLtext(string filePath);
        float getGST();
    }

    
    interface IFileHandling
    {
        string SaveFile(HttpPostedFileBase file, String path);
        string CreateFile(HttpPostedFileBase file, String path, String data);
        void DeleteFile();
        Boolean ValidFile(string data);
    }
}
