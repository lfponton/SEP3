using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IMenusRepository
    {
        Task CreateMenuAsync(Menu menu);
        Task<List<Menu>> GetMenusAsync();
    }
}