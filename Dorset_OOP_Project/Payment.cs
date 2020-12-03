using System;
namespace Dorset_OOP_Project
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

        public Payment(double amount, string method)
        {
            Amount = amount;
            Date = DateTime.Now;
            Method = method;
        }

        public Payment(double amount, DateTime date, string method)
        {
            Amount = amount;
            Date = date;
            Method = method;
        }

        public Payment(double amount, DateTime date, string method, int invoiceId, int paymentId)
        {
            Amount = amount;
            Date = date;
            Method = method;
            InvoiceId = invoiceId;
            PaymentId = paymentId;
        }

        public override string ToString()
        {
            return $"Payment : {PaymentId} / Linked To Invoice : {InvoiceId} / Amount : {Amount} / Date : {Date} / Method : {Method}";
        } 
    }
}
