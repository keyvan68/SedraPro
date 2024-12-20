﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? ImageUrl { get; set; }
        public  UserDetails UserDetails { get; set; }
    }
}
