using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AngularCRUD.Models;

namespace AngularCRUD.Controllers
{
    public class ContactGroupsController : ApiController
    {
        private AngularCRUDContext db = new AngularCRUDContext();

        // GET api/ContactGroups
        public IEnumerable<ContactGroup> GetContactGroups()
        {
            return db.ContactGroups.AsEnumerable();
        }

        // GET api/ContactGroups/5
        public ContactGroup GetContactGroup(int id)
        {
            ContactGroup contactgroup = db.ContactGroups.Find(id);
            if (contactgroup == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return contactgroup;
        }

      

        // POST api/ContactGroups
        public HttpResponseMessage PostContactGroup(ContactGroup contactgroup)
        {
			if (contactgroup.ID != 0)
			{
				db.Entry(contactgroup).State = EntityState.Modified;

				try
				{
					db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					return Request.CreateResponse(HttpStatusCode.NotFound);
				}

				return Request.CreateResponse(HttpStatusCode.OK);
			}
			else
			{
				if (ModelState.IsValid)
				{
					db.ContactGroups.Add(contactgroup);
					db.SaveChanges();

					HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contactgroup);
					response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contactgroup.ID }));
					return response;
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest);
				}
			}
        }

        // DELETE api/ContactGroups/5
        public HttpResponseMessage DeleteContactGroup(int id)
        {
            ContactGroup contactgroup = db.ContactGroups.Find(id);
            if (contactgroup == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ContactGroups.Remove(contactgroup);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contactgroup);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}