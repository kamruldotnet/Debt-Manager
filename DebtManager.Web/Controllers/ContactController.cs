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
    public class ContactController : Controller
    {
        private readonly IAsyncRepository<Contact> _contactRepository;
        

        public ContactController(IAsyncRepository<Contact>  repository)
        {
            _contactRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contactList = await _contactRepository.ListAllAsync();
            return View(contactList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Phone,Email,Address,CreateAt,UpdateAt,Status")] Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactRepository.AddAsync(contact);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet,ActionName("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <=0)
            {
                return RedirectToAction(nameof(Index));
            }

            var contactToUpdate = await _contactRepository.GetByIdAsync(id);
            if(contactToUpdate == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contactToUpdate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contact contact)
        {
            try
            {
                if(id == contact.Id)
                {
                    contact.UpdateAt = DateTime.Now;
                    await _contactRepository.UpdateAsync(contact);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var contact = await _contactRepository.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // Delete/Contact/5
       [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var contact = await _contactRepository.GetByIdAsync(id);
            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Contact contact)
        {
            try
            {
                if(id== contact.Id)
                {
                    await _contactRepository.DeleteAsync(contact);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }



    }
}