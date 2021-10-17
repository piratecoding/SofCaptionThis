using SofCaptionThis.Models;
using System.Threading.Tasks;

namespace SofCaptionThis.Services.Implementation
{
    public interface ICatsService
    {
        Task<Cat> GetCat();
        Task<Cat> GetCatById(string id);
    }
}