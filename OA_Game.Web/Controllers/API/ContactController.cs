using OA_Game.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Game.Web.Controllers.API
{
    public class ContactController : BaseApiController
    {
        // GET: Contact
        public object Post(ContactModel model)
        {
            MailHelp.SendMailForContact(model);
            return true;
        }
    }
}