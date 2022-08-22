using CRUD.Context;
using CRUD.Interfaces.Repository;
using CRUD.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository
{
    public class PostRepository : CommonRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
