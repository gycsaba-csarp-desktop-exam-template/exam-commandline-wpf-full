using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Pagination;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace ServiceKretaAPI
{
    public interface ISubjectService
    {
        Task<List<Subject>>? GetSubjectsAsync(QueryStringParameters queryStringParameter);
        Task<ListWithPaginationData<Subject>>? GetSubjectsAsyncWithPageData(QueryStringParameters queryStringParameter);
        Task<Subject>? GetSubjectByIdAsync(long id);
        Task<long> GetNextSubjectIdAsync();
        Task<System.Net.HttpStatusCode> InsertNewSubjectAsync(Subject subject);
        Task<System.Net.HttpStatusCode> UpdateSubjectAsync(long id, Subject subject);
        Task<System.Net.HttpStatusCode> DeleteSubjectAsync(long id);

    }
}
