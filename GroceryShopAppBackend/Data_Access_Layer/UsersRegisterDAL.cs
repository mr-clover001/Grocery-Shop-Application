using Data_Access_Layer.Repository.Entities;
using GroceryShopApp.Repository;
using GroceryShopApp.Repository.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Data_Access_Layer
{
    public class UsersRegisterDAL
    {

        public List<UsersRegister> GetUsersRegister()
        {
            var db = new ProductDbContext();
            return db.UsersRegister.ToList();
        }


        public void AddUsersRegister(UsersRegister usersRegister)
        {
            usersRegister.MemberSin = System.DateTime.Now;
            var db = new ProductDbContext();
            db.UsersRegister.Add(usersRegister);
            db.SaveChanges();
        }

        public bool IsEmailExists(string email)
        {
            var db = new ProductDbContext();
            return db.UsersRegister.Any(u => u.Email == email);
        }

      
       public UsersRegister IsLogin(UserLogin userLogin)
        {
            using (var db = new ProductDbContext())
            {
                var userAvaiable = db.UsersRegister.Where(u => u.Email == userLogin.Email && u.Password == userLogin.Password).FirstOrDefault();
            
                
                return userAvaiable;
              
            }
        }



    }
}
