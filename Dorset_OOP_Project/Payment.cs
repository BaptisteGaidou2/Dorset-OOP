using System;
namespace Dorset_OOP_Project
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

        public Payment(float amount, string method)
        {
            Amount = amount;
            Date = DateTime.Now;
            Method = method;
        }

        public Payment(float amount, DateTime date, string method)
        {
            Amount = amount;
            Date = date;
            Method = method;
        }
    }
}
