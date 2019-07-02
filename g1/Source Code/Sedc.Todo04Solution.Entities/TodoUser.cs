using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sedc.Todo03Solution.Entities
{
    public class TodoUser : IdentityUser
    {
        public ICollection<Todo> Todos { get; set; }
    }
}
