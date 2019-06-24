using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzApp.Domain
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
