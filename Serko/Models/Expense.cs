using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serko.Models
{
    public abstract class Expense
    {
        [DataType(DataType.Text)]
        [Display(Name = "ID")]
        private int id;

        [DataType(DataType.Text)]
        [Display(Name = "Vendor")]
        private string vendor;

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        private string description;

        [DataType(DataType.Text)]
        [Display(Name = "Date")]
        private string date;

        public int Id { get => id; set => id = value; }
        public string Vendor { get => vendor; set => vendor = value; }
        public string Description { get => description; set => description = value; }
        public string Date { get => date; set => date = value; }
    }

}