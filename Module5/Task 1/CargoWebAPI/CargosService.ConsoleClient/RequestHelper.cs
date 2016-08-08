using System;
using System.Collections.Generic;
using System.Linq;
using CargosService.Common.WebDto;
using RestSharp;

namespace CargosService.ConsoleClient
{
    public class RequestHelper
    {
        public IEnumerable<Guid> Post(RestClient client, int times)
        {
            var request = new RestRequest("Cargos", Method.POST);
            request.AddJsonBody(new CargoDto
            {
                Price = 10,
                Volume = 20,
                Weight = 100,
                RecepientId = Guid.Parse("cca17a58-5bf5-4740-b848-793ddbff6ba6"),
                SenderId = Guid.Parse("cca17a58-5bf5-4740-b848-793ddbff6ba6"),
                RouteId = Guid.Parse("4929F8F7-BAFE-4B00-AD26-8DF04C293B00")
            });
            var idsList = new List<Guid>(times);

            for (var i = 0; i < times; i++)
            {
                var response = client.Execute(request);
                idsList.Add(Guid.Parse(response.Content));
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("Error on repeat {0}. Status code: {1}", i, response.StatusCode);
                }
            }

            return idsList;
        }

        public void Get(RestClient client, IEnumerable<Guid> ids)
        {
            var necessaryIds = ids.Skip(200).Take(100);
            var count = 0;
            foreach (var id in necessaryIds)
            {
                for (int i = 0; i < 50; i++)
                {
                    var request = new RestRequest(string.Format("Cargos/{0}", id), Method.GET);
                    var response = client.Execute(request);
                    if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                    {
                        Console.WriteLine("Get reqeust returned error for id: {0}. Status code: {1}", id, response.StatusCode);
                    }
                    count++;
                }
            }

            Console.Write("Total gets: {0}", count);
        }

        public void Put(RestClient client, IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                var request = new RestRequest("Cargos", Method.PUT);
                request.AddJsonBody(new CargoDto
                {
                    Id = id,
                    Price = 10,
                    RecepientId = Guid.Parse("cca17a58-5bf5-4740-b848-793ddbff6ba6"),
                    SenderId = Guid.Parse("cca17a58-5bf5-4740-b848-793ddbff6ba6"),
                    Volume = 200,
                    Weight = 1,
                    RouteId = Guid.Parse("4929F8F7-BAFE-4B00-AD26-8DF04C293B00")
                });

                var response = client.Execute(request);
                if ((int)response.StatusCode >= 400 || response.StatusCode == 0)
                {
                    Console.WriteLine("PUT reqeust returned error for id: {0}. Status code: {1}", id, response.StatusCode);
                }
            }
        }

        public void Delete(RestClient client, IEnumerable<Guid> ids)
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
