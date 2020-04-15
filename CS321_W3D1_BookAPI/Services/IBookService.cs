using System.Collections.Generic;
using CS321_W3D1_BookAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IBookService
    {
        
        Book Add(Book newBook);
 
        Book Get(int id);

        IEnumerable<Book> GetAll();
   
        Book Update(Book updatedBook); 
 
        void Remove(Book Book);
        
    }
}
