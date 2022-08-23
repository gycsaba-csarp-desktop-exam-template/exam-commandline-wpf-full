using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Pagination;

namespace ServiceKretaAPI
{
    public interface ISubjectService
    {
        Task<List<Subject>>? GetSubjectsAsync();
        Task<ListWithPaginationData<Subject>>? GetSubjectsAsyncWithPageData();
        Task<Subject>? GetSubjectByIdAsync(long id);
        Task<long> GetNextSubjectIdAsync();
        Task<System.Net.HttpStatusCode> InsertNewSubjectAsync(Subject subject);
        Task<System.Net.HttpStatusCode> UpdateSubjectAsync(long id, Subject subject);
        Task<System.Net.HttpStatusCode> DeleteSubjectAsync(long id);

    }
}
