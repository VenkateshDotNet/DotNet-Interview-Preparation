using System.Collections;

namespace PracticeProject
{
    public class Collections
    {
        static void Main()
        {
            int[] arr = new int[3];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine($"second elemet is {arr[0]}");

            ArrayList namelist = new ArrayList();
            namelist.Add("a");
            namelist.Add("b");
            namelist.Add(123);
            foreach (var item in namelist)
            {
                Console.WriteLine(item);
            }
            int number = (int)namelist[2];
            Console.WriteLine($"First item as int: {number}");

            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Venkatesh");
            foreach (var kvp in employees)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }
            string empName = employees[101];
            Console.WriteLine($"Employee 101: {empName}");

            Hashtable ht = new Hashtable(); // Storing data
            ht.Add(1, "Venkatesh");

            Queue q = new Queue();
            q.Enqueue("First");
            foreach (var item in q)
            {
                Console.WriteLine(item); // Output: First, Second, Third }
            }
            var removed = q.Dequeue(); 
            Console.WriteLine($"Removed: {removed}");
        }
    }
}