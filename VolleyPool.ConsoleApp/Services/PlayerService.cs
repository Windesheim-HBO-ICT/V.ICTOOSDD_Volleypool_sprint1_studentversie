using System;
using System.Collections.Generic;
using System.Text;
using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;

namespace VolleyPool.Core.Services
{

        //sprint-3-uc1-invoeren-speler
        public class PlayerService
        {
            private IPlayerRepository PlayerRepository { get; set; }
            public PlayerService(IPlayerRepository playerRepository)
            {
                this.PlayerRepository = playerRepository;
            }

            public Player Add(Player player)
            {
                if(player.BirthDate >= DateTime.Now)
                {
                    throw new ArgumentException("Geboortedatum mag niet in de toekomst liggen.");
                }
                return PlayerRepository.Add(player);
            }
        }
    }
