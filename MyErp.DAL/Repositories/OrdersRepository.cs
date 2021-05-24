using Microsoft.EntityFrameworkCore;
using MyErp.DAL.Models;
using MyErp.DAL.Repositories.Interfaces;

namespace MyErp.DAL.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(DbContext context) : base(context)
        { }




        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
