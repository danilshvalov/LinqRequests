using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductInfo[] itemInStock = new[]
            {
                new ProductInfo { Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo { Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo { Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo { Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo { Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo { Name = "Classic Valpo Pizza", Description = "Everyone loves pizza", NumberInStock = 73}
            };

            SelectEverything(itemInStock);
            GetOverstock(itemInStock);
            GetNameAndDescription(itemInStock);

            foreach(var item in GetProjectSubset(itemInStock))
                Console.WriteLine(item);
            Console.WriteLine();

            GetCountFromQuery();
            ReverseEverything(itemInStock);
            AlphabetizeProductNames(itemInStock);

            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcat();
            DisplayConcatWithOutDups();

            AgregateOps();

            Console.ReadLine();
        }
        static void SelectEverything(ProductInfo[] products)
        {
            var subset = from item in products select item;
            foreach(var item in subset)
                Console.WriteLine(item.Name);
            Console.WriteLine();
        }
        static void GetOverstock(ProductInfo[] products)
        {
            var subset = from item in products where item.NumberInStock > 25 select item;
            foreach (var item in subset)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void GetNameAndDescription(ProductInfo[] products)
        {
            var subset = from item in products select new { item.Name, item.Description };
            foreach (var item in subset)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static Array GetProjectSubset(ProductInfo[] products)
        {
            var subset = from item in products select item;
            return subset.ToArray();
        }
        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            var subset = from item in currentVideoGames where item.Length > 6 select item;
            Console.WriteLine($"Count: {subset.Count()}");
        }
        static void ReverseEverything(ProductInfo[] products)
        {
            var subset = from item in products select item;

            foreach(var item in subset.Reverse())
                Console.WriteLine(item.Name);
            Console.WriteLine();
        }
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            var subset = from item in products orderby item.Name descending select item;

            foreach (var item in subset)
                Console.WriteLine(item.Name);
            Console.WriteLine();
        }
        static void DisplayDiff()
        {
            List<string> first = new List<string>() { "Yogo", "BMW", "Aztec"};
            List<string> second = new List<string>() { "Saab", "Aztec", "BMW" };

            var carDiff = (from item in first select item).Except((from item in second select item));

            Console.WriteLine("Different:");
            foreach(var item in carDiff)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void DisplayIntersection()
        {
            List<string> first = new List<string>() { "Yogo", "BMW", "Aztec" };
            List<string> second = new List<string>() { "Saab", "Aztec", "BMW" };

            var carDiff = (from item in first select item).Intersect((from item in second select item));

            Console.WriteLine("Same:");
            foreach (var item in carDiff)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void DisplayUnion()
        {
            List<string> first = new List<string>() { "Yogo", "BMW", "Aztec" };
            List<string> second = new List<string>() { "Saab", "Aztec", "BMW" };

            var carDiff = (from item in first select item).Union((from item in second select item));

            Console.WriteLine("Like Set():");
            foreach (var item in carDiff)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void DisplayConcat()
        {
            List<string> first = new List<string>() { "Yogo", "BMW", "Aztec" };
            List<string> second = new List<string>() { "Saab", "Aztec", "BMW" };

            var carDiff = (from item in first select item).Concat((from item in second select item));

            Console.WriteLine("Summary (Concat):");
            foreach (var item in carDiff)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void DisplayConcatWithOutDups()
        {
            List<string> first = new List<string>() { "Yogo", "BMW", "Aztec" };
            List<string> second = new List<string>() { "Saab", "Aztec", "BMW" };

            var carDiff = (from item in first select item).Concat((from item in second select item));

            Console.WriteLine("Summary (Concat) without dups:");
            foreach (var item in carDiff.Distinct())
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static void AgregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine($"Max temps: {(from item in winterTemps select item).Max()}");
            Console.WriteLine($"Min temps: {(from item in winterTemps select item).Min()}");
            Console.WriteLine($"Average temps: {(from item in winterTemps select item).Average()}");
            Console.WriteLine($"Summary temps: {(from item in winterTemps select item).Sum()}");
        }
    }   
}
