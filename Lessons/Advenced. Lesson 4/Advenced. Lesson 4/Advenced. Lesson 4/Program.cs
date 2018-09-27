using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advenced.Lesson_4
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            GCExample();




            Console.ReadLine();
        }
       
        public static void GCExample()
        {
            Console.WriteLine($"HeavyObject.Count {HeavyObject.Count}");

            Int32 counter = 0;
            Int32 iterations = 500_000;

            while (counter < iterations)
            {
                var obj = new HeavyObject();
                //obj.Dispose();

                counter++;

                if (counter % 50_000 == 0)
                {
                    Console.WriteLine($"Befor 0 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");
                    GC.Collect(0);
                    Console.WriteLine($"After 0 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");
                                    
                    Console.WriteLine($"Befor 1 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");
                    GC.Collect(1);
                    Console.WriteLine($"After 1 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");

                    Console.WriteLine($"Befor 2 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");
                    GC.Collect(2);
                    Console.WriteLine($"After 2 Collect: HeavyObject.Count {HeavyObject.Count}       GetTotalMemory {System.GC.GetTotalMemory(false)}");

                }
                
            }
        }

        public static void LifeCycleExample()
        {
            var cache = new Dictionary<int, WeakReference>();
            for (int i = 0; i < 20; i++)
            {
                cache.Add(i, new WeakReference(new List<string> { "abc" }));
            }
        }

        public static Dictionary<int, string> Method()
        {
            var localNumber = 3;

            var localDictionary = 
                new Dictionary<int, string> {
                    { 234, "Petya" },
                    { 123, "Vasya" }
                };

            var localDictionary2 =
                new Dictionary<int, string> {
                    { 345, "Olga" },
                    { 345, "Dash" }
                };

            return localDictionary2;
        }
    }

    public class HeavyObject: IDisposable
    {
        public static Int64 Count { get; set; }

        public bool disposed = false;


        public HeavyObject()
        {
            HeavyObject.Count++;
        }

        ~HeavyObject()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed == false)
            {
                HeavyObject.Count--;
                disposed = true;
            }
            
        }
    }

    // Design pattern for a base class.
    public class Base : IDisposable
    {
        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~Base()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}
