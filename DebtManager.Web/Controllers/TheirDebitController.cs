using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtManager.Core.Entities;
using DebtManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DebtManager.Web.Controllers
{
    public class TheirDebitController : Controller
    {
        private readonly IAsyncRepository<TheirDebt> _theirDebitRepository;


        public TheirDebitController(IAsyncRepository<TheirDebt> repository)
        {
            _theirDebitRepository = repository;
        }
        

        public async Task<IActionResult> Index()
        {
            var theirDebit = await _theirDebitRepository.ListAllAsync();
            return View(theirDebit);
        }

        // GET: TheirDebit/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var theirDebit = await _theirDebitRepository.GetByIdAsync(id);
            if(theirDebit == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(theirDebit);
        }


        // GET: CREATE 
        public async Task<IActionResult> Create()
        {
            return View();
        }


        // POST: THEIR DEBIT/CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TheirDebt theirDebt)
        {
            if(theirDebt == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _theirDebitRepository.AddAsync(theirDebt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: THEIR DEBIT/EDIT
        public async Task<IActionResult> Edit(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var theirDebit = await _theirDebitRepository.GetByIdAsync(id);
            if(theirDebit == null)
            {
                return RedirectToAction(nameof(id));
            }

            return View(theirDebit);
        }


        // POST: TheirDebit/EDIT
        public async Task<IActionResult> Edit(int id,TheirDebt theirDebt)
        {
            if(id != theirDebt.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _theirDebitRepository.UpdateAsync(theirDebt);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        //GET: TheirDebit/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var deleteItem = await _theirDebitRepository.GetByIdAsync(id);
            if(deleteItem == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(deleteItem);
        }


        //POST: TheirDebit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TheirDebt theirDebt)
        {
            if(id != theirDebt.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            await _theirDebitRepository.DeleteAsync(theirDebt);
            return RedirectToAction(nameof(Index));
        }
       
    }
}