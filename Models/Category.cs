﻿namespace E_ticket.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<Movie> movies { get; set; }
    }
}
