using System.Threading.Tasks;

public interface IUserInformationService
{
    public Task<User> GetUser(int id);
}