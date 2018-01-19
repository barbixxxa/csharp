
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebSystem.Models;

namespace WebSystem.Controllers
{
    public class UserController : Controller
    {

        DataBaseConnect dbc = new DataBaseConnect();
        List<User> ListadeUsuarios = new List<User>();
        User usuario = new User();


        // GET: User
        [HttpGet]
        public ViewResult Index(string sortOrder, string searchUser)
        {
            ViewBag.LoginSortParm = string.IsNullOrEmpty(sortOrder) ? "login_asc" : "";
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            ViewBag.MailSortParm = string.IsNullOrEmpty(sortOrder) ? "mail_asc" : "";
            ListadeUsuarios = dbc.Select();
            var users = from u in ListadeUsuarios select u;

            if (!string.IsNullOrEmpty(searchUser))
            {
                users = users.Where(u => u.UserName.ToLowerInvariant().Contains(searchUser.ToLowerInvariant())
                || u.UserLogin.ToLowerInvariant().Contains(searchUser.ToLowerInvariant())
                || u.UserEmail.ToLowerInvariant().Contains(searchUser.ToLowerInvariant()));
            }

            switch (sortOrder)
            {
                case "login_asc":
                    users = users.OrderBy(u => u.UserLogin);
                    break;
                case "name_asc":
                    users = users.OrderBy(u => u.UserName);
                    break;
                case "mail_asc":
                    users = users.OrderBy(u => u.UserEmail);
                    break;
                default:
                    users = users.OrderBy(u => u.UserId);
                    break;
            }

            return View(users.ToList());
        }

        //Create User
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create User
        [HttpPost]
        public ActionResult Create(User userNew)
        {
            if (ModelState.IsValid)
            {
                dbc.Insert(userNew);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit User
        public ActionResult Edit(int id)
        {
            usuario = dbc.SearchById(id);
            return View(usuario);
        }

        //POST: Edit User
        [HttpPost]
        public ActionResult Edit(User userEdit)
        {
            if (ModelState.IsValid)
            {
                dbc.Update(userEdit);
                return RedirectToAction("Index");
            }
            return View(userEdit);


        }
        //Delete User
        public ActionResult Delete(int id)
        {
            usuario = dbc.SearchById(id);
            return View(usuario);
        }

        //POST: Delete User
        [HttpPost]
        public ActionResult Delete(User userDel)
        {
            dbc.Delete(userDel.UserId);
            return RedirectToAction("Index");
        }



    }
}