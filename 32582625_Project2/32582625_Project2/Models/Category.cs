using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _32582625_Project2;

namespace _32582625_Project2.Models
{
    public partial class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}