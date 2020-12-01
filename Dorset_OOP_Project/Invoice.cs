using System;
using System.Collections.Generic;

namespace Dorset_OOP_Project
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public float Amount { get; set; }
        public List<Payment> Payments { get; set; }

        public Invoice ()
        {
            Amount = 8000;
            Payments = new List<Payment>();
        }

        public Invoice(float amount)
        {
            Amount = amount;
            Payments = new List<Payment>();
        }

        public Invoice(float amount, List<Payment> payments)
        {
            Amount = amount;
            Payments = payments;
        }

        public float OutstandingBalance()
        {
            float total = Amount;
            foreach(Payment payment in Payments)
            {
                total -= payment.Amount;
            }
            return total;
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }

        public void PrintPayments()
        {
            foreach(Payment payment in Payments)
            {
                Console.WriteLine($"Payment : {payment.PaymentId} / Amount : {payment.Amount} / Method : {payment.Method}");
            }
        }
    }
}
