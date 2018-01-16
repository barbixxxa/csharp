namespace CadastroUsuario
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string profile { get; set; }

        public User(int id, string login, string password, string name, string profile)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.profile = profile;
        }
    }
}

