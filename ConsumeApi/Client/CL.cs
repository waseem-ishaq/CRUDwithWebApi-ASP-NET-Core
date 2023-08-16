using ConsumeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace ConsumeApi.Client
{

    
    public class CL
    {

        List<Employee> list = new List<Employee>();
        HttpClient client = new HttpClient();

        string ApiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiUrl")["Url"];

        [HttpGet]
        public List<Employee> GAE()
        {
            List<Employee> list = new List<Employee>();
            client.BaseAddress = new Uri(ApiUrl);
            var response = client.GetAsync("values");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                list = display.Result;
            }
            return list;    
        }

        [HttpPost]
        public bool AE(Employee emp)
        {
            client.BaseAddress = new Uri(ApiUrl);
            var response = client.PostAsJsonAsync<Employee>("values", emp);
            response.Wait();

            var test = response.Result;
            return (test.IsSuccessStatusCode);
        }

        [HttpGet]
        public Employee GE(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri(ApiUrl);
            var response = client.GetAsync("values?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return (e);
        }

        [HttpPost]
        public bool UE(int id, Employee emp)
        {
            client.BaseAddress = new Uri(ApiUrl);
            var response = client.PutAsJsonAsync<Employee>("values?id=" + id.ToString(), emp);
            response.Wait();

            var test = response.Result;
            return (test.IsSuccessStatusCode);
        }

        [HttpPost, ActionName("Delete")]
        public bool DE(int id)
        {
            client.BaseAddress = new Uri(ApiUrl);
            var response = client.DeleteAsync("values/" + id.ToString());
            response.Wait();

            var test = response.Result;
            return (test.IsSuccessStatusCode);
        }
    }
}
