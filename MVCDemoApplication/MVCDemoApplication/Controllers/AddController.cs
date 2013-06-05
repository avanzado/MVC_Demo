using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoApplication.Models;
namespace MVCDemoApplication.Controllers
{
    public class AddController : Controller
    {
        //
        // GET: /Add/
        [HttpGet]
        public ActionResult Add()
        {
        
            if (Request.QueryString.Count>0)
            {
                if (Request.QueryString["page"] != null)
                {
                    var lst = PropertyMaster.GetList();
                    return View("AddRecord", lst.AsEnumerable());

                } 
                else if (Request.QueryString["sort"] != null && Request.QueryString["sortdir"] != null)
                {
                    var lst = PropertyMaster.GetList(Request.QueryString["sort"].ToString(), Request.QueryString["sortdir"].ToString());
                    return View("AddRecord", lst.AsEnumerable());

                }
            }

         

            //var PropertyList = PropertyMaster.GetList();
            return View("");
         
        }
        [HttpPost]
        public ActionResult Add(PropertyMaster objPropertyMaster)
        {
           
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                objPropertyMaster.AddData(objPropertyMaster);
            }
            else
            {
               
            }

            var lst = PropertyMaster.GetList();
            return View("AddRecord", lst.AsEnumerable());
        }
       

    }
}
