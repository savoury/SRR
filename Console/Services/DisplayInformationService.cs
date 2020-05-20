using System.Collections.Generic;
using System.Threading.Tasks;

public class DisplayInformationService : IDisplayInformationService
{
    private readonly IUserInformationService _userInformationService;
    private readonly IPostInformationService _postInformationService;
    public DisplayInformationService(IUserInformationService userInformationService, 
                                IPostInformationService postInformationService)
    {
        _userInformationService = userInformationService;
        _postInformationService = postInformationService;
    }

    public async Task<List<DisplayInformation>> GetInformation(int userId)
    {
        var user = await _userInformationService.GetUser(userId);
        var postsUserId = await _postInformationService.GetPosts(userId);

        List<DisplayInformation> res = new List<DisplayInformation>();
        foreach(var elem in postsUserId)
        {
            res.Add(new DisplayInformation{ Id = elem.Id, JobTitle = elem.Title, Name = user.Name }); 
        }

        return res;
    }
}