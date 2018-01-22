
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebSystem.Models;
using PagedList;
using System;

namespace WebSystem.Controllers
{
    public class UserController : Controller
    {

        DataBaseConnect dbc = new DataBaseConnect();
        List<User> ListadeUsuarios = new List<User>();
        User usuario = new User();


        // GET: User
        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchUser, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LoginSortParm = (string.IsNullOrEmpty(sortOrder) || sortOrder != "login_asc") ? "login_asc" : "login_desc";
            ViewBag.NameSortParm = (string.IsNullOrEmpty(sortOrder) || sortOrder != "name_asc") ? "name_asc" : "name_desc";
            ViewBag.MailSortParm = (string.IsNullOrEmpty(sortOrder) || sortOrder != "mail_asc") ? "mail_asc" : "mail_desc";
            ViewBag.IdSortParm = (string.IsNullOrEmpty(sortOrder) || sortOrder != "id_desc") ? "id_desc" : "id_asc";

            if (searchUser != null)
            {
                page = 1;
            }
            else
            {
                searchUser = currentFilter;
            }

            ViewBag.CurrentFilter = searchUser;

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
                case "login_desc":
                    users = users.OrderByDescending(u => u.UserLogin);
                    break;
                case "name_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                case "mail_desc":
                    users = users.OrderByDescending(u => u.UserEmail);
                    break;
                case "id_desc":
                    users = users.OrderByDescending(u => u.UserId);
                    break;
                default:
                    users = users.OrderBy(u => u.UserId);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(users.ToPagedList(pageNumber, pageSize));


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

        [HttpPost]
        public ActionResult DeleteSelected(FormCollection formColletion)
        {

            string[] ids = formColletion["userDelId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {

                dbc.Delete(int.Parse(id));
            }

            return RedirectToAction("Index");
        }



    }
}