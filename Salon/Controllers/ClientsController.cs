using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Salon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly SalonContext _db;

        public ClientsController(SalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Clients.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client, int StylistId)
        {
            _db.Clients.Add(client);
            if (StylistId != 0)
            {
                _db.StylistClient.Add(new StylistClient() { StylistId = StylistId, ClientId = client.ClientId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddStylist(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult AddStylist(Client client, int StylistId)
        {
            if (StylistId != 0)
            {
                _db.StylistClient.Add(new StylistClient() { StylistId = StylistId, ClientId = client.ClientId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisClient = _db.Clients
                .Include(client => client.Stylists)
                .ThenInclude(join => join.Stylist)
                .FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }

        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View(thisClient);
        }
        [HttpPost]
        public ActionResult Edit(Client client, int StylistId)
        {
            if (StylistId != 0)
            {
                _db.StylistClient.Add(new StylistClient() { StylistId = StylistId, ClientId = client.ClientId });
            }
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult DeleteStylist(int joinId)
        {
            var joinEntry = _db.StylistClient.FirstOrDefault(entry => entry.StylistClientId == joinId);
            _db.StylistClient.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}