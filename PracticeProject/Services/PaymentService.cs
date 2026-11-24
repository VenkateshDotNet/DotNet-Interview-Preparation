namespace PracticeProject
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> ProcessPayment(decimal amount)
        { 
          await Task.Delay(1000); 
            return true; 
        }
    }
}
