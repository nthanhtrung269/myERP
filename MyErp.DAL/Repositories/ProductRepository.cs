using Microsoft.EntityFrameworkCore;
using MyErp.DAL.Models;
using MyErp.DAL.Repositories.Interfaces;

namespace MyErp.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        { }




        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
