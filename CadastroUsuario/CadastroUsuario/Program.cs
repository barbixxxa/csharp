using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var user = new User(75421658, "admin", "123", "boss", "administrador");
            var user2 = new User(9598, "tec", "456", "tech", "tecnico");
            UserRepository ur = new UserRepository();

            //INSERIR USUARIO
            int addUser1 = ur.Insert(user);
            int addUser2 = ur.Insert(user2);
            Console.WriteLine("Inserir" + $"\n\tUsuario 1: {addUser1}" + $"\n\tUsuario 2: {addUser2} \n");

            //USUARIO DUPLICADO
            ur.Insert(user); 

            //BUSCAR USUARIO
            var searchUser1 = ur.Get(user.id);
            var searchUser2 = ur.Get(1);
            Console.WriteLine("Buscar" + $"\n\tUsuario 1: {searchUser1.id}" + $"\n\tUsuario inexistente: {searchUser2.id} \n");

            //REMOVER USUARIO
            bool delUser1 = ur.Delete(searchUser1.id);
            searchUser1 = ur.Get(user.id);
            Console.WriteLine("Remover" + $"\n\tUsuario 1 foi deletado: {delUser1}" + $"\n\tUsuario 1: {searchUser1.id} \n");

        }
    }
}
