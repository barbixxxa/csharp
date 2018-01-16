using System;
using System.Collections.Generic;

namespace CadastroUsuario
{
    public class UserRepository
    {
        private List<User> userRep;

        public UserRepository()
        {
            userRep = new List<User>();
        }

        public int Insert(User user)
        {
            if(this.Get(user.id).id == -1)
            {
                userRep.Add(user);
                return user.id;
            }
            else
            {
                Console.WriteLine("Usuario já inserido");
                return 0;
            }
            
        }

        public bool Update(User newUser, int idOldUser)
        {
            return false;
        }

        public bool Delete(int idUser)
        {
            if(this.Get(idUser).id != -1)
            {
                userRep.Remove(this.Get(idUser));
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        public User Get(int idUser)
        {
            User ret = new User(-1, null, null, null, null);
            foreach (var user in userRep)
            {
                if (user.id == idUser)
                {
                    ret = (User)user;
                    break;
                }
                else
                    if (ret.id == -1)
                {
                   
                }
            }
            return ret;
        }

        /*public List<User> Getall()
        {
        }*/
    }
}

