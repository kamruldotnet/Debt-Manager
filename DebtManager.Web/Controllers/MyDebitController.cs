using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtManager.Core.Entities;
using DebtManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtManager.Web.Controllers
{
    public class MyDebitController : Controller
    {

        private readonly IAsyncRepository<MyDebit> _myDebitRepository;

        public MyDebitController(IAsyncRepository<MyDebit> repository)
        {
            _myDebitRepository = repository;
        }

        // GET: MyDebt
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var myDebitList = await _myDebitRepository.ListAllAsync();
            return View(myDebitList);
        }

        // GET: MyDebt/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id<=0)
            {
                return RedirectToAction(nameof(Index));
            }
            var myDebtDetail = await _myDebitRepository.GetByIdAsync(id);
            if(myDebtDetail == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(myDebtDetail);
        }

        // GET: MyDebt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyDebt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MyDebit myDebt)
        {
            if(myDebt == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                myDebt.CreateAt = DateTime.Now;
                myDebt.UpdateAt = DateTime.Now;
                myDebt.Status = true;
                await _myDebitRepository.AddAsync(myDebt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyDebt/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var myDebit = await _myDebitRepository.GetByIdAsync(id);
            if (myDebit == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(myDebit);
        }

        // POST: MyDebt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MyDebit mydebit)
        {
            if(id != mydebit.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _myDebitRepository.UpdateAsync(mydebit);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyDebt/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var deleteItem = await _myDebitRepository.GetByIdAsync(id);
            if(deleteItem== null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(deleteItem);
        }

        // POST: MyDebt/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, MyDebit myDebit)
        {
            if(id != myDebit.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _myDebitRepository.DeleteAsync(myDebit);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}