using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace SampleConsole
{
    internal static class MultiThreadDictionary
    {
        public static void RunDictionary()
        {
            ConcurrentDictionary<string, ConcurrentBag<int>> cache = new();
            const string key = nameof(MultiThreadDictionary);

            Parallel.ForEach(Enumerable.Range(0, 10), i =>
            {
                ConcurrentBag<int> cachedInts;

                lock (cache)
                {
                    if (!cache.ContainsKey(key))
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"Creating new List<int> (i={i})");
                        cache[key] = new ConcurrentBag<int>();
                    }
                    else
                    {
                        Console.WriteLine($"Using existing List<int> (i={i})");
                    }
                }

                cachedInts = cache[key];
                cachedInts.Add(i);
                Console.WriteLine($"Values for i={i}: {string.Join(",", cachedInts)}");
            });
        }

        public static void RunMemoryCache()
        {
            ConcurrentDictionary<string, ConcurrentBag<int>> cache = new();
            const string key = nameof(MultiThreadDictionary);

            Parallel.ForEach(Enumerable.Range(0, 10), i =>
            {
                ConcurrentBag<int> cachedInts;

                lock (cache)
                {
                    if (!cache.ContainsKey(key))
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"Creating new List<int> (i={i})");
                        cache[key] = new ConcurrentBag<int>();
                    }
                    else
                    {
                        Console.WriteLine($"Using existing List<int> (i={i})");
                    }
                }

                cachedInts = cache[key];
                cachedInts.Add(i);
                Console.WriteLine($"Values for i={i}: {string.Join(",", cachedInts)}");
            });
        }
    }
}
