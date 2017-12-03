using MaratonaXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaratonaXamarin.Services
{
    public interface IVargolaService
    {
        Task<List<Tag>> GetTagsAsync();

        Task<List<Content>> GetContentsByTagIdAsync(string tagId);

        Task<List<Content>> GetContentsByFilterAsync(string filter);
    }
}
