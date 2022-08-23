using CRUD.Models;
using EF.Core.Repository.Interface.Manager;

namespace CRUD.Interfaces.Manager
{
    public interface IPostManager: ICommonManager<Post>
    {
        Post GetById(int id);

    }
}
