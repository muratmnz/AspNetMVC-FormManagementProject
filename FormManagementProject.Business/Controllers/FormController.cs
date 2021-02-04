using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormManagementProject.DataAccess.Models;

namespace FormManagementProject.Business.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
       
        public ActionResult List(string name)
        {
            using (FormDbEntities db = new FormDbEntities())
            {
                var values = from d in db.Form select d;
                if (!string.IsNullOrEmpty(name))
                {
                    values = values.Where(m => m.name.Contains(name));
                }
                return View(values.ToList());
            }

        }
        
        public ActionResult AddForm()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddForm(Form form)
        {
            using (FormDbEntities db = new FormDbEntities())
            {
                UsersEntities userDb = new UsersEntities();

                Form newForm = new Form();

                int userId = userDb.Users.FirstOrDefault(x => x.username == System.Web.HttpContext.Current.User.Identity.Name).Id;

                if (form.name != null && form.formUserName != null && form.formUserSurname != null )
                {
                    newForm.Id = form.Id;
                    newForm.name = form.name;
                    newForm.description = form.description;
                    newForm.createdAt = DateTime.Now;
                    newForm.createdBy = Convert.ToInt32(userId);
                    newForm.fields = form.fields;
                    newForm.formUserName = form.formUserName;
                    newForm.formUserSurname = form.formUserSurname;
                    newForm.formUserAge = form.formUserAge;
                    db.Form.Add(newForm);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {                  
                    return RedirectToAction("List");
                }
                    

                
            }

        }

        [Route("Form/{id:int}")]
        public ActionResult Details(int id)
        {
           using(FormDbEntities db = new FormDbEntities()) { 
            Form detailForm = db.Form.Find(id);

            return View(detailForm);
            }
        }
        [HttpPost]
        public ActionResult Details(Form form)
        {
            using(FormDbEntities db = new FormDbEntities()) 
            {

                Form detailForm = db.Form.Find(form.Id);
                detailForm.createdAt = form.createdAt;
                detailForm.name = form.name;
                detailForm.description = form.description;
                detailForm.formUserName = form.formUserName;
                detailForm.formUserSurname = form.formUserSurname;
                detailForm.formUserAge = form.formUserAge;
                
                return RedirectToAction("List");
            }
        }

    }
}