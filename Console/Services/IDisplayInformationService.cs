using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDisplayInformationService
{
    public Task<List<DisplayInformation>> GetInformation(int userId);
}