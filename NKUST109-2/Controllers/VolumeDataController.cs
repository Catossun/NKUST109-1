using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KHLightTrail;
using NKUST109_2.Data;

namespace NKUST109_2.Controllers
{
    public class VolumeDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolumeDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VolumeDatas
        public async Task<IActionResult> Index(int? year)
        {
            List<VolumeData> volumeDatas;
            if (year == null)
            {
                volumeDatas = await _context.VolumeDatas.ToListAsync();
            }
            else
            {
                ViewData["year"] = year;
                volumeDatas = _context.VolumeDatas.Where(volumeData => volumeData.Year == year).ToList();
            }
            return View(volumeDatas);
        }

        // GET: VolumeDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumeData = await _context.VolumeDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volumeData == null)
            {
                return NotFound();
            }

            return View(volumeData);
        }

        // GET: VolumeDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolumeDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Month,TotalVolume,AverangeDailyVolume,AvgHolidayVolume,AvgBuyTicketWithCardOnPlatform,AvgBuyTicketWithCardOnTrain,AvgBuyTicketFromTicketMachine,AvgRebuyTicket,AvgBuyGroupTicket,AvgBuyTicketByManual,Remark")] VolumeData volumeData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volumeData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volumeData);
        }

        // GET: VolumeDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumeData = await _context.VolumeDatas.FindAsync(id);
            if (volumeData == null)
            {
                return NotFound();
            }
            return View(volumeData);
        }

        // POST: VolumeDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,Month,TotalVolume,AverangeDailyVolume,AvgHolidayVolume,AvgBuyTicketWithCardOnPlatform,AvgBuyTicketWithCardOnTrain,AvgBuyTicketFromTicketMachine,AvgRebuyTicket,AvgBuyGroupTicket,AvgBuyTicketByManual,Remark")] VolumeData volumeData)
        {
            if (id != volumeData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volumeData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolumeDataExists(volumeData.Id))
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
            return View(volumeData);
        }

        // GET: VolumeDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumeData = await _context.VolumeDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volumeData == null)
            {
                return NotFound();
            }

            return View(volumeData);
        }

        // POST: VolumeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volumeData = await _context.VolumeDatas.FindAsync(id);
            _context.VolumeDatas.Remove(volumeData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolumeDataExists(int id)
        {
            return _context.VolumeDatas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ImportFromOfficial()
        {
            List<VolumeData> newVolumeDatas = await VolumeDataset.GetAllVolumes();
            newVolumeDatas.ForEach(data =>
            {
                _context.VolumeDatas.Add(data);
                _context.SaveChanges();
            });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteAll()
        {
            DeleteAllDataWithoutSaving();
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private void DeleteAllDataWithoutSaving()
        {
            DbSet<VolumeData> volumeDatas = _context.VolumeDatas;
            foreach (VolumeData volumeData in volumeDatas)
            {
                volumeDatas.Remove(volumeData);
            }
        }
    }
}