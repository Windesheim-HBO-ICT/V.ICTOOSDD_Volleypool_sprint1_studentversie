using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;

namespace VolleyPool.Data.Repostories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Player[] players = [
            new Player { MemberId = 1, Name = "Lucas", BirthDate = new DateTime(2000, 1, 21), ParentOneId = "piet@odido.nl" },
            new Player { MemberId = 2, Name = "Carmen", BirthDate = new DateTime(2002, 5, 31), ParentOneId = "jolanda@gmail.com" },
            new Player { MemberId = 3, Name = "Quinten", BirthDate = new DateTime(2005, 8, 15), ParentOneId = "willem@gmail.com" },
            new Player { MemberId = 4, Name = "Fleur", BirthDate = new DateTime(2011, 8, 3), ParentOneId = "marieke@gmail.com" },
        ];

        public Player Add(Player player)
        { //sprint-3-uc1-invoeren-speler

            // This is just a mock implementation, in a real scenario you would add the player to a database and return the added player with its new ID.
            player.MemberId = players.Length + 1; // Simulate auto-increment ID
            var newPlayers = new Player[players.Length + 1];
            for (int i = 0; i < players.Length; i++)
            {
                newPlayers[i] = players[i];
            }
            newPlayers[players.Length] = player;
            players = newPlayers;
            return player;
        }

        public Player? Delete(Player player)
        {
            throw new NotImplementedException();
        }

        public Player? Get(int id)
        {
            foreach (Player player in players)
            {
                if (player.MemberId == id) return player;
            }

            return null;
        }

        public Player[] GetAll()
        {
            return players;
        }

        public Player? Update(Player player)
        {
           var entity = Get(player.MemberId);
            if (entity == null) return null;
            entity.Name = player.Name;
            entity.BirthDate = player.BirthDate;
            entity.ParentOneId = player.ParentOneId;
            entity.ParentTwoId = player.ParentTwoId;
            entity.CancellationIds = player.CancellationIds;
            return player;
        }
    }
}
