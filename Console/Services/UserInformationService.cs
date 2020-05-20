using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class UserInformationService : IUserInformationService
{
    public async Task<User> GetUser(int userId)
    {
       HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($" https://jsonplaceholder.typicode.com/users/{userId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }
        else
            throw new HttpRequestException("No user found at the url for this userId");
    }
}