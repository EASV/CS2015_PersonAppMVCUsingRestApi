using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonApplicationDll.Entities;


namespace PersonApplicationDll.Managers
{
    class WishServiceGateway : IServiceGateway<Wish>
    {
        public Wish Create(Wish wish)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1922/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/wishes", wish).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Wish>().Result;
                }
                return null;
            }
            
        }

        public Wish Read(int id)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1922/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/wishes/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Wish>().Result;
                }
                return null;
            }
        }

        public List<Wish> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1922/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/wishes").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Wish>>().Result;
                }
            }
            return new List<Wish>();
        }

        public Wish Update(Wish t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1922/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync($"/api/wishes/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Wish>().Result != null;
                }
                return false;
            }
        }
        
    }
}
