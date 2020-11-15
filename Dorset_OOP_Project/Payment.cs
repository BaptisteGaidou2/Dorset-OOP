using System;
namespace Dorset_OOP_Project
{
    public class Payment
    {
        public float Amount { get; set; }
        public Student Student { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }

        public Payment(float amount, Student student, Invoice invoice, DateTime date, string method)
        {
            Amount = amount;
            Student = student;
            Invoice = invoice;
            Date = date;
            Method = method;
        }

        public void Add()
        {
            Invoice.Payments.Add(this);
        }
    }
}
