using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Backoffice.AppLogic._Global;
using DAS.Domain.Model;
using DAS.Backoffice.Shared;


namespace DAS.Backoffice.Controllers
{
    public class LoginController : DASController
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            Session["DASUser"] = null;
            return View();
      
            
        }

        public ActionResult LoginAction(String email, String password)
        {
            bool loggedIn = false;
            User userDB = Db.Users.Where(u => u.Username == email && u.Password == password).FirstOrDefault();

            if (userDB != null)
            {

                 loggedIn = true;
                 DASUser user = new DASUser();
                 user.SelectedLanguageId = 1;
                 user.UserName = userDB.Username;
                 Session["DASUser"] = user;
           
            }
            else
            {
                loggedIn = false;
            }


           
            return Json(new { success = loggedIn });
        }

    }
}
