using System;
using System.Collections.Generic;
using DAL.Module.Common.WebDto;
using RestSharp;

namespace DAL.Module.ConsoleClient
{
    public class RequestHelper
    {
        public IEnumerable<int> Post(RestClient client, int times)
        {
            var request = new RestRequest("Cargos", Method.POST);
            request.AddJsonBody(new CargoDto
            {
                Price = 10,
                RecepientId = 1,
                SenderId = 1,
                Volume = 20,
                Weight = 100,
                RouteId = 1
            });
            var idsList = new List<int>(times);

            for (var i = 0; i < times; i++)
            {
                var response = client.Execute(request);
                idsList.Add(int.Parse(response.Content));
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("Error on repeat {0}. Status code: {1}", i, response.StatusCode);
                }
            }

            return idsList;
        }

        public void Get(RestClient client, IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var request = new RestRequest(string.Format("Cargos/{0}", id), Method.GET);
                var response = client.Execute(request);
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("Get reqeust returned error for id: {0}. Status code: {1}", id, response.StatusCode);
                }
            }
        }

        public void Put(RestClient client, IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var request = new RestRequest("Cargos", Method.PUT);
                request.AddJsonBody(new CargoDto
                {
                    Id = id,
                    Price = 10,
                    RecepientId = 1,
                    SenderId = 1,
                    Volume = 200,
                    Weight = 1,
                    RouteId = 1
                });

                var response = client.Execute(request);
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("PUT reqeust returned error for id: {0}. Status code: {1}", id, response.StatusCode);
                }
            }
        }

        public void Delete(RestClient client, IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var request = new RestRequest(string.Format("Cargos/{0}", id), Method.DELETE);
                var response = client.Execute(request);
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("DELETE reqeust returned error for id: {0}. Status code: {1}", id, response.StatusCode);
                }
            }
        }
    }
}
