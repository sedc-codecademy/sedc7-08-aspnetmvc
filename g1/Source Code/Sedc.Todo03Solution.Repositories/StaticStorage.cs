using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sedc.Todo03Solution.Entities;

namespace Sedc.Todo03Solution.Repositories
{
    public static class StaticStorage<TModel> where TModel : BaseEntity
    {
        public static List<TModel> DataSet { get; set; }

        static StaticStorage()
        {
            DataSet = new List<TModel>();
        }
    }
}
