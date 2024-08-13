namespace Rasyotek.WEBUI.ApiCallsServices.Abstract
{
    public interface IUniversityService
    {
        Task<List<string>> GetUniversitiesAsync();
    }
}
