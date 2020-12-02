using System;
using System.Collections.Generic;

namespace Dorset_OOP_Project
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int StudentId { get; set; }
        public float Amount { get; set; }
        public List<Payment> Payments { get; set; }

        public Invoice()
        {
            Amount = 8000;
            Payments = new List<Payment>();
        }

        public Invoice(float amount)
        {
            Amount = amount;
            Payments = new List<Payment>();
        }

        public Invoice(float amount, int invoiceId)
        {
            Amount = amount;
            Payments = new List<Payment>();
            InvoiceId = invoiceId;
        }

        public Invoice(float amount, List<Payment> payments)
        {
            Amount = amount;
            Payments = payments;
        }

        public Invoice(float amount, int invoiceId, int studentId)
        {
            Amount = amount;
            InvoiceId = invoiceId;
            StudentId = studentId;
            Payments = new List<Payment>();
        }

        public float OutstandingBalance()
        {
            float total = Amount;
            foreach (Payment payment in Payments)
            {
                total -= payment.Amount;
            }
            return total;
        }

        public bool AddPayment(Payment payment)
        {
            if (OutstandingBalance() < 0 || OutstandingBalance() - payment.Amount < 0)
            {
                return false;
            }
            Payments.Add(payment);
            payment.InvoiceId = InvoiceId;
            return true;
        }

        public string PaymentsInformation()
        {
            string information = "";
            foreach (Payment payment in Payments)
            {
                information += $"Payment : {payment.PaymentId} / Amount : {payment.Amount} / Method : {payment.Method} \n";
            }
            return information;
        }

        public override string ToString()
        {
            return $"Invoice : {InvoiceId} / Amount : {Amount} / Outstanding : {OutstandingBalance()} \n{PaymentsInformation()}";
        }
    }
}
