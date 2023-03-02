using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Models
{
    public interface Repository
    {
        IQueryable<Books> Bookz { get; }
    }
}
