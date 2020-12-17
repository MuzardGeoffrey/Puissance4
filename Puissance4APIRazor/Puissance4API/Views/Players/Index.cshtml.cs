using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Puissance4API.Data;
using Puissance4API.Models;

namespace Puissance4API
{
    public class IndexModel : PageModel
    {
        private readonly Puissance4API.Data.PlayerContext _context;

        public IndexModel(Puissance4API.Data.PlayerContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Players.ToListAsync();
        }
    }
}
