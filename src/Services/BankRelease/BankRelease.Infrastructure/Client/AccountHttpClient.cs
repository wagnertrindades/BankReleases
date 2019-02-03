using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankRelease.Infrastructure.Client
{
    public class AccountHttpClient
    {
        public HttpClient Client { get; }

        public AccountHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }

        public async Task<Uri> CheckingAccountDebit(int accountId, decimal value)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                "api/checking-account/{accountId}/debit", value);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<Uri> CheckingAccountCredit(int accountId, decimal value)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                "api/checking-account/{accountId}/credit", value);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
