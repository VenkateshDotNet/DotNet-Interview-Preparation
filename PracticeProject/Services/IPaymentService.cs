namespace PracticeProject
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(decimal amount);
    }
}
