using System;
using System.Linq;
using System.Threading.Tasks;
using CelebritiesAPI.Core.EntityLayer;

namespace CelebritiesAPI.Core.DataLayer
{
    public interface ICelebritiesRepository : IDisposable
    {
        IQueryable<Celebrity> GetCelebrities();

        Task<Celebrity> GetCelebrityAsync(Celebrity entity);

        Task<Celebrity> AddCelebrityAsync(Celebrity entity);

        Task<Celebrity> UpdateCelebrityAsync(Celebrity changes);

        Task<Celebrity> DeleteCelebrityAsync(Celebrity changes);
    }
}
