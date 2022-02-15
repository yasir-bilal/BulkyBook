using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Models.DAL
{
    public interface _IAllRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int CategoryID);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
        void Save();
    }
}
