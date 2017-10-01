using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebChat.Models
{
    public class UserContext:DbContext
    {
        public UserContext() : base("UserContext") { }
        public DbSet<User> Users { get; set; }
    }
}