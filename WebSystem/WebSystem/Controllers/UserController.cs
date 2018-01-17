
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            ListadeUsuarios = dbc.Select();
            return View(ListadeUsuarios);
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
            usuario = dbc.Search(id);
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
            usuario = dbc.Search(id);
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