using System;
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
            userRep.add(user);
        }

        public bool Update(User newUser, int idOldUser)
        {

        }

        public bool Delete(int idUser)
        {
            userRep.remove(this.Get(idUser));
        }

        public User Get(int idUser)
        {
            User ret = null;
            foreach(var user in userRep)
            {
                if(user.id == idUser)
                {
                    ret = (User)user;
                    break;
                }else
                    if(ret == null)
                {

                }
            }
            return ret;
        }

        public List<User> Getall()
        {

        }
    }
}

