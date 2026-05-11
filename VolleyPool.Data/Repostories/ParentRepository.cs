using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;

namespace VolleyPool.Data.Repostories
{
    public class ParentRepository : IParentRepository
    {
        private Parent[] parents = [
            new Parent { Name = "Piet", Email = "piet@odido.nl", Phone = "06-25364829", Password = "hetregentbuiten", PlayerMemberId = 1},
            new Parent { Name = "Jolanda", Email = "jolanda@gmail.com", Phone = "+316-53486753", Password = "jolandasportopdecampus", PlayerMemberId = 2},
            new Parent { Name = "Jaap", Email = "jaap@volley-pool.com", Phone = "+316-53486763", Password = "jaapiseenwandelaar", PlayerMemberId = 2}
            // Currently the password are stored as plain text. This is bad practice and very dangerous. Use hashing instead.

        ];

        public Parent Add(Parent parent)
        {
            Parent[] newParents = new Parent[parents.Length + 1];

            for (int i = 0; i < parents.Length; i++)
            {
                newParents[i] = parents[i];
            }

            newParents[newParents.Length - 1] = parent;
            parents = newParents;

            return parent;
        }

        public Parent? Delete(Parent parent)
        {
            throw new NotImplementedException();

            // Its a good practice in C# to throw a NotImplementedException to stop
            // executing the program if any developer tries to call code that has not
            // been implemented yet.

        }

        public Parent? Get(string id)
        {
            foreach (var parent in parents)
            {
                if (parent.Email == id) return parent;
            }
            return null;
        }

        public Parent[] GetAll()
        {
            return parents;
        }

        public Parent? Update(Parent parent)
        {
            var entity = Get(parent.Email);
            if (entity == null) return null;
            var index = parents.IndexOf(entity);
            parents[index] = parent;
            return parent;

            // For the sake of simplicity, validations are omitted.
        }
    }
}
