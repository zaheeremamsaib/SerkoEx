using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Serko.Models
{
    public class Upload
    {

        [DataType(DataType.Text)]
        [Display(Name = "ID")]
        private int id;

        [DataType(DataType.Text)]
        [Display(Name = "File")]
        private string file;

        [DataType(DataType.Text)]
        [Display(Name = "Data")]
        private string data;

        public int Id { get => id; set => id = value; }
        public string File { get => file; set => file = value; }
        public string Data { get => data; set => data = value; }
    }
}