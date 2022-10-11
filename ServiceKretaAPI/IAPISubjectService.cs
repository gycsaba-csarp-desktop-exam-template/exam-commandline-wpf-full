using Kreta.Models.DataModel;
using Kreta.Models.Helpers;
using Kreta.Models.Parameters;

namespace ServiceKretaAPI
{
    public interface IAPISubjectService
    {
        Task<List<Subject>>? GetSubjectsAsync(QueryStringParameters queryStringParameter);
        Task<PagedList<Subject>>? GetSubjectsAsyncWithPageData(QueryStringParameters queryStringParameter);
        Task<Subject>? GetSubjectByIdAsync(long id);
        Task<long> GetNextSubjectIdAsync();
        Task<System.Net.HttpStatusCode> InsertNewSubjectAsync(Subject subject);
        Task<System.Net.HttpStatusCode> UpdateSubjectAsync(long id, Subject subject);
        Task<System.Net.HttpStatusCode> DeleteSubjectAsync(long id);

    }
}
