using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string host = "https://swapi.dev/api/people";

            ServicePointManager.ServerCertificateValidationCallback =
                          delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                          {
                              return true;
                          };
            var client = new HttpClient();
            var response = client.GetStringAsync(host).Result;

            List<PeopleModel> lstPeopleModel = new List<PeopleModel>();
            //if (!string.IsNullOrEmpty(response))
            //{
            dynamic peopleObj = JsonConvert.DeserializeObject(response);
            
            PeopleModel model = null;
            foreach (var obj in peopleObj.results)
            {
                List<string> _films = new List<string>();
                foreach(var films in obj.films)
                {
                    _films.Add(@""+films);
                }

                model = new PeopleModel()
                {
                    name = obj.name,
                    films = _films.ToArray()
                };
                lstPeopleModel.Add(model);
            }

            string names = "";
            foreach(var people in lstPeopleModel)
            {
                foreach(var film in people.films)
                {
                    if()
                }
            }

            //.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
            //var group = lstPeopleModel.GroupBy(x => new {x.films,x.name }).Where(g => g.Key.films.Length > 1).Select(a=>new Person() {m_name=a.Key.name ,m_films = a.Key.films });
        }

    }
}
