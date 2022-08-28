using CRUD.Context;
using CRUD.Interfaces.Manager;
using CRUD.Models;
using CRUD.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace CRUD.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager
    {
        public PostManager(ApplicationDbContext applicationDbContext) : base(new PostRepository(applicationDbContext))
        {

        }

        public ICollection<Post> GetAllByTitle(string title)
        {
            return Get(p=>p.Title.ToLower()==title.ToLower());
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(p => p.Id == id);
        }
    }
}
