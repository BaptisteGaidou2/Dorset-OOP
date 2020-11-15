using System;
using System.Collections.Generic;

namespace Dorset_OOP_Project
{
    public class Invoice
    {
        public float Amount { get; set; }
        public List<Payment> Payments { get; set; }
        public Invoice(float amount, List<Payment> payments)
        {
            Amount = amount;
            Payments = payments;
        }

        public float OustandingBalance()
        {
            float total = Amount;
            foreach(Payment payment in Payments)
            {
                total -= payment.Amount;
            }
            return total;
        }
    }
}
