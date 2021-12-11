using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IMenusService
    {
        Task<List<Menu>> GetMenusAsync();
        Task<Menu> CreateMenuAsync(Menu menu);
    }
}