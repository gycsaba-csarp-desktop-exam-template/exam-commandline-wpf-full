using KretaParancssoriAlkalmazas.Models.DataModel;

namespace KretaRazorPages.Services.Interface
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectsAsync();
        Task<long> GetNextSubjectId();
    }
}
