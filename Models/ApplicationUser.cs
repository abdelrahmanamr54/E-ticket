﻿using Microsoft.AspNetCore.Identity;

namespace E_ticket.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

    }
}
