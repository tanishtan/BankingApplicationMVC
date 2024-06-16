using BankingApp.Process;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Entities;

namespace BankingApplicationMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly BankingProcess _process; // Inject BankingProcess

        public AccountsController(BankingProcess process)
        {
            _process = process;
        }
        public IActionResult List()
        {
            var accounts = _process.GetAllAccounts();
            if(accounts != null) 
            {
                return View(accounts);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Create form for new account
        }

        [HttpGet]
        [ActionName("AddNew")]
        public IActionResult CreateNewAccount()
        {
            // No changes needed here
            var model = new AccountInfo();
            return View(viewName: "Create",model: model); // Create form for new account
        }

        [HttpPost]
        public IActionResult Create(AccountInfo account)
        {
            if (ModelState.IsValid) // Validate data
            {
                var createdAccount = _process.CreateNewAccount(account.Id, account.Name, account.Type, account.Balance);
                if (createdAccount != null)
                {
                    return RedirectToAction("List");
                }
                // Handle unsuccessful creation
            }
            return View(account); // Re-render with errors
        }


        public IActionResult Details(int id)
        {
            var account = _process.findAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _process.findAccountById(id);
            if (model == null)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, AccountInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _process.UpdateAccountDetails(model, model.Id.ToString(), model.Name, model.Balance.ToString());
            return RedirectToAction(nameof(List));
        }

        public IActionResult Remove(int id)
        {
            //string sId = id.ToString();
            var model = _process.findAccountById(id);
            if (model != null)
            {
                return View(model);
                _process.RemoveAccountById(id);   
            }
            return RedirectToAction("List");
        }

        //[ActionName("Remove")]
        //[HttpPost]
        /*public IActionResult RemoveConfirmed(int customerId)
        {
            _process.RemoveAccountById(customerId);
            return RedirectToAction(nameof(List));  // Redirect to List action after deletion
        }*/
    }
}
