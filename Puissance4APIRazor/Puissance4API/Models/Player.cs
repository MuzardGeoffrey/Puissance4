﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puissance4API.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Pseudo{ get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
    }
}
