using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
namespace AddressBook.Controllers;

public class HomeController : Controller
{
    private readonly IAddressManager addressManager;

    private readonly ILogger<HomeController> _logger;

    public HomeController(IAddressManager _addressManager, ILogger<HomeController> logger)
    {
        this.addressManager = _addressManager;

        _logger = logger;
    }

    ContactViewModel contactViewModel = new ContactViewModel();

    public IActionResult Home()
    {
        this.contactViewModel.NewContact = new Contact();
        this.contactViewModel.Contacts = addressManager?.GetContacts();
        return View(this.contactViewModel);
    }

    public IActionResult DisplayContact(int ContactId)
    {
        int contactId = Convert.ToInt32(ContactId);
        this.contactViewModel.Contacts = addressManager?.GetContacts();
        this.contactViewModel.EditContact = addressManager.GetContact(contactId: contactId);
        return View(contactViewModel);
    }

    public IActionResult Delete(int ContactId)
    {
        addressManager.DeleteContact(ContactId: ContactId);
        return RedirectToAction("Home");
    }

    [HttpPost]
    public IActionResult Edit(ContactViewModel model)
    {
        Contact contact = model.EditContact;
        addressManager.EditContact(contact);
        return RedirectToAction("Home");
    }

    [HttpPost]
    public IActionResult AddContact(Contact newContact)
    {
        if (ModelState.IsValid)
        {
            addressManager.AddContact(newContact);
            return RedirectToAction("Home");
        }
        else
        {
            this.contactViewModel.Contacts = addressManager?.GetContacts();
            this.contactViewModel.NewContact=newContact;
            return View(contactViewModel);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
