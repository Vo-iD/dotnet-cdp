﻿using System;
using System.Diagnostics;
using RestSharp;

namespace DAL.Module.ConsoleClient
{
    public class Program
    {
        private const string BaseUrl = "http://localhost:64814/api";
        private const int Repeats = 1000000;

        static void Main(string[] args)
        {
            Console.WriteLine("Create client to url: {0}", BaseUrl);
            var client = new RestClient(BaseUrl);
            var helper = new RequestHelper();

            var watcher = new Stopwatch();
            Console.WriteLine("POST started. {0} times", Repeats);
            watcher.Start();

            var insertedIds = helper.Post(client, Repeats);

            watcher.Stop();
            Console.WriteLine("POST finished. Elapsed: {0}", watcher.Elapsed);

            Console.WriteLine("GET started. {0} times", Repeats);
            watcher.Restart();

            helper.Get(client, insertedIds);

            watcher.Stop();
            Console.WriteLine("GET finished. Elapsed: {0}", watcher.Elapsed);

            Console.WriteLine("PUT started. {0} times", Repeats);
            watcher.Restart();

            helper.Put(client, insertedIds);

            watcher.Stop();
            Console.WriteLine("PUT finished. Elapsed: {0}", watcher.Elapsed);

            Console.WriteLine("DELETE started. {0} times", Repeats);
            watcher.Restart();

            helper.Delete(client, insertedIds);

            watcher.Stop();
            Console.WriteLine("DELETE finished. Elapsed: {0}", watcher.Elapsed);

            Console.ReadLine();
        }
    }
}
