using System.Net.Http.Headers;
using System.Text;

namespace AppTeste.Requisicoes;

public class RequisicaoHttp
{
    public static async Task<string> GetRequisicao(string url)
    {
        Uri urlNova = new Uri(url);
        HttpClient httpClient = new HttpClient();

        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlNova);
            HttpResponseMessage responseGet = await httpClient.SendAsync(request);
            string responseContent = await responseGet.Content.ReadAsStringAsync();

            return responseContent;
        }
        finally
        {
            httpClient.Dispose();
        }
    }

    public static async Task<string> PostRequisicao(string json, string url)
    {
        Uri urlNova = new Uri(url);

        HttpClient httpClient = new HttpClient();

        try
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(urlNova, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
        finally
        {
            httpClient.Dispose();
        }
    }
}
