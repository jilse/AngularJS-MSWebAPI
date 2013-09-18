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
    public class ContactsController : ApiController
    {
        private AngularCRUDContext db = new AngularCRUDContext();

        // GET api/Contacts
        public IEnumerable<Contact> GetContacts()
        {
            return db.Contacts.AsEnumerable();
        }

        // GET api/Contacts/5
        public Contact GetContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return contact;
        }
           // POST api/Contacts
        public HttpResponseMessage PostContact(Contact contact)
        {
			if (contact.ID != 0)
			{
				db.Entry(contact).State = EntityState.Modified;

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
					db.Contacts.Add(contact);
					db.SaveChanges();

					HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contact);
					response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contact.ID }));
					return response;
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest);
				}
			}
        }

        // DELETE api/Contacts/5
        public HttpResponseMessage DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Contacts.Remove(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}