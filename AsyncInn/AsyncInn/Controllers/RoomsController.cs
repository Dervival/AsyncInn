using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
namespace AsyncInn.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomConfigManager _context;

        //private readonly AsyncInnDbContext _context;

        public RoomsController(IRoomConfigManager context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index(string NameEntered)
        {
            var rooms = await _context.GetConfigurations();

            if (!String.IsNullOrEmpty(NameEntered))
            {
                rooms = rooms.Where(search => search.Name.Contains(NameEntered));
            }
            foreach (Room room in rooms)
            {
                room.AmenityCount = _context.AmentityCount(room);
            }
            //TODO: Figure out how to properly grab the count of rooms and put into ViewBag
            //List<int> roomCount = new List<int> {1,2,3,4,5,6,7,8,9 };
            //ViewBag.roomCount = roomCount;


            return View(rooms);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurations = await _context.GetConfiguration((int)id);
            if (configurations == null)
            {
                return NotFound();
            }

            return View(configurations);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateConfiguration(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rooms = await _context.GetConfiguration((int)id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);

        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateConfiguration(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rooms = await _context.GetConfiguration((int)id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.DeleteConfiguration(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            var rooms = _context.GetConfiguration((int)id);
            if (rooms == null)
            {
                return false;
            }
            return true;
        }
    }
}
