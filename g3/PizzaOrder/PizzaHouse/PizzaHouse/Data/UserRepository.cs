//using System.Collections.Generic;
//using System.Linq;
//using PizzaHouse.Models;

//namespace PizzaHouse.Data
//{
//    public class UserRepository : IRepository<User>
//    {
//        public List<User> GetAll()
//        {
//            return Storage.Users;
//        }

//        public User GetById(int id)
//        {
//            return Storage.Users.FirstOrDefault(x => x.Id == id);
//        }

//        public void Create(User obj)
//        {
//            Storage.Users.Add(obj);
//        }

//        public void Update(User obj)
//        {
//            var singleObject = Storage.Users.FirstOrDefault(x => x.Id == obj.Id);

//            if (singleObject != null)
//            {
//                Storage.Users.Remove(singleObject);
//                Storage.Users.Add(obj);
//            }
//        }

//        public void Delete(User obj)
//        {
//            Storage.Users.Remove(obj);
//        }
//    }
//}
