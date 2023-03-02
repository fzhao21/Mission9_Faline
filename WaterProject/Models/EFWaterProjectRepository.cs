using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFWaterProjectRepository : IWaterProjectRepository
    {
        private BookstoreContext context { get; set; }
        public EFWaterProjectRepository(BookstoreContext temp)
        {
            context = temp;

        }
        public IQueryable<Books> Books => context.Books;

    }
}
