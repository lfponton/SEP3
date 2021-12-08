using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IMenusService
    {
        Task<List<Menu>> GetMenus();
        Task<Menu> CreateMenuAsync(Menu menu);

        Task<Menu> CreateMenu(Menu newMenu);

        Task<Menu> GetMenuAsync(int menuId);



    }
}