using Serko.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serko.Models
{
    public class TotalExpense : Expense
    {
        [DataType(DataType.Text)]
        [Display(Name = "Total Expense ID")]
        private int te_id;

        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "Cost Center not specified")]
        [Display(Name = "Cost Center")]
        private string costCentre;
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "Total not specified")]
        [Display(Name = "Total")]
        private float total;
        [DataType(DataType.Currency)]
        [Display(Name = "Total excl GST")]
        private float totalExcl;
        [DataType(DataType.Text)]
        [Display(Name = "GST")]
        private float gst;
        [DataType(DataType.Text)]
        [Display(Name = "GST Amount")]
        private float gstAmount;
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "Payment Method not specified")]
        [Display(Name = "Payment Method")]
        private string payment_method;

        public string CostCentre { get => costCentre; set => costCentre = value; }
        public float Total { get => total; set => total = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public int Te_id { get => te_id; set => te_id = value; }
        public float TotalExcl { get => totalExcl; set => totalExcl = value; }
        public float Gst { get => gst; set => gst = value; }
        public float GstAmount { get => gstAmount; set => gstAmount = value; }
    }
}