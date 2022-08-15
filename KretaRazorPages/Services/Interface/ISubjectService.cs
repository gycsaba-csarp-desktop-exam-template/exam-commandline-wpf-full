using KretaParancssoriAlkalmazas.Models.DataModel;

namespace KretaRazorPages.Services.Interface
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectAsync();
    }
}
