using CRUD.Models;
using EF.Core.Repository.Interface.Repository;

namespace CRUD.Interfaces.Repository
{
    public interface IPostRepository: ICommonRepository<Post>
    {
    }
}
