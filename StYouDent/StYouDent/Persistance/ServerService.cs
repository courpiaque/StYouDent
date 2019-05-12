using Newtonsoft.Json;
using StYouDent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StYouDent.Persistance
{
    public class ServerService : IServerService
    {
        public async Task<string> GetRequest(string adress)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(adress);
                return response.ToString();
            }
        }

        public Task<string> SendLogin(string email, string pass)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hackathon-student-backend.herokuapp.com/login");

            request.Method = "POST";
            request.ContentType = "application/json";

            string json = "{\"email\":\"" + email + "\", \"password\":\"" + pass + "\"}";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();

                return Task.FromResult(responseText);
            }
        }

        public async Task<string> SendRequest(string json, string adress)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(adress, new StringContent(json, Encoding.UTF8, "application/json"));
                return response.ToString();
            }
        }
    }
}
