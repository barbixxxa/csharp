public class User{
	public int id {get; set;}
	public string login {get; set;}
	public string password {get; set;}
	public string confirmPassword {get; set;}
	public string name {get; set;}
	public Profile Profile {get; set;}
	
	public string ProfileName{
		get{return Profile.getDescription();}
	}


}