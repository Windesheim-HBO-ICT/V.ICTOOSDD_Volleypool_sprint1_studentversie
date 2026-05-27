using VolleyPool.Core.Models;

namespace VolleyPool.Core.Interfaces.Repositories
{
    public interface IParentRepository
    {
        public Parent[] GetAll();

        public Parent? Get(string id);


        public Parent Add(Parent parent);

        public Parent? Delete(Parent parent);

        public Parent? Update(Parent parent);
    } 
}
