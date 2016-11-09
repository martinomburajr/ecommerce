using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel.Models.BusinessModel
{
    public class UserService : ServiceManager
    {
        public User getUserByEmail(string email)
        {
            User user = db.Users.FirstOrDefault(i => i.EmailAddress.Equals(email));
            return user;
        }

        public User getUserById(int id)
        {
            User customer = db.Users.FirstOrDefault(i => i.Id.Equals(id));
            return customer;
        }

        public Boolean validateLogin(String email, String password, String status)
        {
            bool valid = false;
            try
            {
                User customer = getUserByEmail(email);
                if (customer.Password.Equals(password))
                {
                    valid = true;
                }else
                {
                    valid = false;
                }
            }
            catch (Exception)
            {
                
            }
            return valid;
        }

        public Boolean CreditStatusOK(string emailAddress, decimal total)
        {
            User customer = this.getUserByEmail(emailAddress);
            if (total > customer.Account)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean DeductCredit(int customerId, decimal amount) 
        {
            bool done = false;
            try
            {
                User customer = this.getUserById(customerId);
                customer.Account = customer.Account - amount;
                done = true;
            }
            catch(Exception)
            {
              
            }
            return done;           
        }

        public Boolean DeductCredit(String email, decimal amount)
        {
            bool done = false;
            try
            {
                User customer = this.getUserByEmail(email);
                customer.Account = customer.Account - amount;
                done = true;
            }
            catch (Exception)
            {

            }
            return done;
        }
    }
}
