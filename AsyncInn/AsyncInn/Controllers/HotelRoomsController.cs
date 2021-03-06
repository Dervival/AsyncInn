﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        //// GET: HotelRooms/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hotelRoom = await _context.HotelRooms
        //        .Include(h => h.Hotel)
        //        .Include(h => h.Room)
        //        .FirstOrDefaultAsync(m => m.HotelId == id);
        //    if (hotelRoom == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hotelRoom);
        //}

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,RoomNumber,RoomId,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                throw new Exception("One of the ids was null! hotelID:" + hotelID + " roomID:" + roomNumber);
                //return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            if (hotelRoom == null)
            {
                throw new Exception("No hotel room found with hotelID " + hotelID + " and roomID " + roomNumber);
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelId, int roomNumber, [Bind("HotelId,RoomNumber,RoomId,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            //if (id != hotelRoom.HotelId)
            //{
            //    throw new Exception("id did not match hotelRoom.HotelID! id: " + id + ", hotelRoom.HotelID:" + hotelRoom.HotelId);
            //    //return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    var existingHotelRoom = await _context.HotelRooms
                    .Include(h => h.Hotel)
                    .Include(h => h.Room)
                    .FirstOrDefaultAsync(m => m.HotelId == hotelRoom.HotelId && m.RoomNumber == hotelRoom.RoomNumber);
                    if (existingHotelRoom == null)
                    {
                        existingHotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);
                        _context.HotelRooms.Remove(hotelRoom);
                        _context.Add(hotelRoom);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomId);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelId == hotelID && m.RoomNumber == roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hotelID, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id);
        }
    }
}
