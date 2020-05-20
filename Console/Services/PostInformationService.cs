using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PostInformationService : IPostInformationService
{
    public async Task<List<Post>> GetPosts()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content);
        }
        else
            throw new HttpRequestException("No post information found at the url");
    }

    public async Task<List<Post>> GetPosts(int userId)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"http://jsonplaceholder.typicode.com/posts?userId={userId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content);
        }
        else
            throw new HttpRequestException("No post information found at the url for this userId");
    }
}