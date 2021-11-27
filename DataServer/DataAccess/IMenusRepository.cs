using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IMenusRepository
    {
        Task<Menu> CreateMenuAsync(Menu menu);
        Task<List<Menu>> GetMenusAsync();
    }
}