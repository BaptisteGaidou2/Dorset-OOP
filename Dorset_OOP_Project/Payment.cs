using System;
namespace Dorset_OOP_Project
{
    public class Payment
    {
        public float Amount { get; set; }
        public Student Student { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime Date { get; set; }

        public Payment(float amount, Student student, Invoice invoice, DateTime date)
        {
            Amount = amount;
            Student = student;
            Invoice = invoice;
            Date = date;
        }

        public void Add()
        {
            Invoice.Payments.Add(this);
        }
    }
}
