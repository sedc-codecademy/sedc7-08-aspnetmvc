using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApplicationDemo.Controllers
{
    public class SedcController : Controller
    {
        private string[] groups = new string[]
        {
            "g1","g2","g3","g4","g5","g6","g7","g8",
        };
        public string GetGroups(int skip = 0, int take=100)
        {
            var result = groups.Skip(skip).Take(take);
            return JsonConvert.SerializeObject(result);
        }
        public string Index()
        {
            var data = new string[] { "g1", "g2" };
            return JsonConvert.SerializeObject(data);
        }

        public int GetNumberOfGroups()
        {
            return 6 + 2;
        }
    }
}