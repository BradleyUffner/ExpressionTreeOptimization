using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new List<TestClass>
                         {
                             new TestClass {Name = "Bradley", Key = 1, IsAwesome = true},
                             new TestClass {Name = "Charlie", Key = 2, IsAwesome = true},
                             new TestClass {Name = "Sam", Key = 3, IsAwesome = false},
                             new TestClass {Name = "Leo", Key = 4, IsAwesome = true},
                         }.AsQueryable();

            var query = source.Where(d => !d.IsAwesome && !d.IsAwesome && d.SubData.TrueProp && (!d.IsAwesome &&
                                          (!d.IsAwesome && !d.IsAwesome && !d.SubData.FalseProp && !d.IsAwesome)) &&
                                          !d.IsAwesome && (!d.IsAwesome && !d.IsAwesome && !d.IsAwesome &&
                                          !d.IsAwesome && !d.IsAwesome && !(d.SubData.FalseProp && d.SubData.FalseProp)) &&
                                          d.Name.EndsWith("m"));
            Console.WriteLine("Unoptimized:");
            Console.WriteLine(query.Expression);
            Console.WriteLine("Result:");
            Console.WriteLine(query.First().Name);

            Console.WriteLine();
            Console.WriteLine();

            query = query.Optimize();
            Console.WriteLine("Optimized:");
            Console.WriteLine(query.Expression);
            Console.WriteLine("Result:");
            Console.WriteLine(query.First().Name);

            Console.WriteLine();
            Console.WriteLine();

            var stopWatch = new Stopwatch();
            var iterations = 100000;
            var store = new List<object>(iterations); // just storing results so they can't be optimized away
            stopWatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                store.Add(query.Optimize());
            }

            stopWatch.Stop();
            Console.WriteLine($"{store.Count} iterations = {stopWatch.Elapsed.TotalMilliseconds}ms");

            Console.ReadKey();
        }
    }
}