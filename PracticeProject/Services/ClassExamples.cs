namespace PracticeProject
{
    public static class ClassExamples
    {
        //A static class in C# is a class declared with the static keyword. It cannot be instantiated,
        //cannot be inherited, and can only contain static members. 
        private static decimal taxRate = 0.18m; 
        public static decimal CalculateTax(decimal amount) 
        {
            return amount * taxRate; 
        }
        public static string FormatCurrency(decimal amount)
        {
            return $"₹{amount:N2}";
        }
        class Program
        {
            static void Main()
            {
                decimal price = 1000m;
                decimal tax = CalculateTax(price);
                Console.WriteLine($"Tax: {FormatCurrency(tax)}");
            }
        }
        public partial class Employee
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
        public partial class Employee
        {
            public decimal Salary { get; set; }
            public void CalculateBonus() => Console.WriteLine("Bonus calculated");
        }


    }
}
