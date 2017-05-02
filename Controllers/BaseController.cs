using groupePjvApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        public IDal dal;

        public BaseController()
            : this(new Dal())
        {
            ViewData["produits"] = dal.ObtenirLesProduits();
            ViewData["magasins"] = dal.ObtenirLesMagasins();
        }

        public BaseController(Dal dal)
        {
            this.dal = dal;
        }        
    }
}