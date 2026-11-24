namespace PracticeProject
{
    public class SolidPrinciples
    {
        //Single Responsibility : A class should have only one reason to change.
        //x
        public class Report {
            public string GetReport() => "Report data"; 
            public void PrintReport(string report) => Console.WriteLine(report); 
        }
        //* 
        public class ReportGenerator
        {
            public string GetReport() => "Report data";
        }
        public class ReportPrinter
        {
            public void PrintReport(string report) => Console.WriteLine(report);
        }
        //Open/Closed Principle : Classes should be open for extension but closed for modification.
        //*
        public interface IPayment { void Pay(decimal amount); }
        public class CreditCardPayment : IPayment 
        {
            public void Pay(decimal amount) => Console.WriteLine("Paid by Credit Card"); 
        }
        public class PayPalPayment : IPayment 
        { 
            public void Pay(decimal amount) => Console.WriteLine("Paid by PayPal");
        }
        //Liskov Substitution : Subclasses should be substitutable for their base classes.
        //x
        public class Bird
        {
            public virtual void Fly() { }
        }
        public class Penguin : Bird
        {
            public override void Fly() => throw new NotSupportedException();
        }
        //*
        public abstract class Birds { }
        public class FlyingBird : Birds
        {
            public void Fly() => Console.WriteLine("Flying...");
        }
        public class Penguins : Bird
        {
            public void Swim() => Console.WriteLine("Swimming...");
        }
        //Liskov Substitution : Subclasses should be substitutable for their base classes.
        //x
        public interface IWorker
        {
            void Work();
            void Eat();
        }
        //*
        public interface IWorkable { void Work(); }
        public interface IFeedable { void Eat(); }

        public class Robot : IWorkable
        {
            public void Work() => Console.WriteLine("Robot working");
        }
        public class Human : IWorkable, IFeedable
        {
            public void Work() => Console.WriteLine("Human working");
            public void Eat() => Console.WriteLine("Human feedable");
        }
        //Dependency Inversion :Depend on abstractions, not concrete implementations.
        //Controller depending on IPaymentService instead of PaymentService.
        public interface IPaymentService
        {
            void ProcessPayment(decimal amount);
        }

        public class PaymentService : IPaymentService
        {
            public void ProcessPayment(decimal amount) => Console.WriteLine("Payment processed");
        }

        public class CheckoutController
        {
            private readonly IPaymentService _paymentService;
            public CheckoutController(IPaymentService paymentService)
            {
                _paymentService = paymentService;
            }
            public void Pay(decimal amount) => _paymentService.ProcessPayment(amount);
        }

    }
}
