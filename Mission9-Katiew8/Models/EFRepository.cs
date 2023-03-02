using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Models
{
    public class EFRepository : Repository
    {
        private BookstoreContext context { get; set; }

        public EFRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Bookz => context.Books;
    }
}
