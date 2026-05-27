using VolleyPool.Core.Models;

namespace VolleyPool.Core.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        public Player[] GetAll();

        public Player? Get(int id);


        public Player Add(Player player);

        public Player? Delete(Player player);

        public Player? Update(Player player);
    }
}
