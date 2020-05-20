using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPostInformationService
{
    public Task<List<Post>> GetPosts();
    public Task<List<Post>> GetPosts(int userId);
}