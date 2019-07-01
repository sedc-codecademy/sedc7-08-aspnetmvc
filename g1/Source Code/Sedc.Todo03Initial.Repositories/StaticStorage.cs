using System.Collections.Generic;
using System.Linq;
using Sedc.Todo03Initial.Entities;

namespace Sedc.Todo03Initial.Repositories
{
    public static class StaticStorage<TModel> where TModel: BaseEntity
    {
        public static List<TModel> DataSet { get; set; }

        static StaticStorage()
        {
            DataSet = new List<TModel>();
        }
    }
}
