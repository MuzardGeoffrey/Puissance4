using Puissance4API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puissance4API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlayerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
                {
                    new Player{Pseudo = "Jason",Password="test",Score=3},
                    new Player{Pseudo = "Miaou",Password="chat",Score=5},
                };

            context.Players.AddRange(players);
            context.SaveChanges();
        }
    }
}
