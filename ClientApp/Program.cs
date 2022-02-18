using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClientApp
{
    internal class Program
    {


        public async void DataPost(Account data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("Account", data).Result;


                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }


            }

        }

        static void Main(string[] args)
        {

            Console.Write("please enter user details..");
            Console.WriteLine("enter user id:");

            var id = Console.ReadLine();
            Console.WriteLine("enter user Name:");
            var name = Console.ReadLine();

            var account = new Account() { Id = Convert.ToInt32(id), Name = name, AccountNumber = 12132323 };

            Program pr = new Program();

            pr.DataPost(account);

            Console.ReadLine();
        }
    }
}
