
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

        //Add User
        public ActionResult Add()
        {
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


    }
}