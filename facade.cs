    public class AccountService
    {
        public void GetAccout(string email)
        {
            Console.WriteLine("Getting the account of " + email);
        }
    }
    
    public class EmailService
    {
        public void SendMail(string mailTo)
        {
            Console.WriteLine("Sending an email to " + mailTo);
        }
    }
    
    public class PaymentService
    {
        public void PaymentByPaypal()
        {
            Console.WriteLine("Payment by Paypal");
        }
        public void PaymentByCreditCard()
        {
            Console.WriteLine("Payment by Credit Card");
        }
        public void PaymentByEBankingAccount()
        {
            Console.WriteLine("Payment by E-banking account");
        }
        public void PaymentByCash()
        {
            Console.WriteLine("Payment by cash");
        }
    }
    
    public class ShippingService
    {
        public void FreeShipping()
        {
            Console.WriteLine("Free Shipping");
        }

        public void StandardShipping()
        {
            Console.WriteLine("Standard Shipping");
        }

        public void ExpressShipping()
        {
            Console.WriteLine("Express Shipping");
        }
    }
    
    public class SmsService
    {
        public void sendSMS(string mobilePhone)
        {
            Console.WriteLine("Sending an message to " + mobilePhone);
        }
    }