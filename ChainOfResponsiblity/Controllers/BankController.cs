using ChainOfResponsiblity.ChainOfResbonsiblity;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsiblity.Controllers
{
    public class BankController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Withdraw p)
        {
            Employee treasurer=new Treasurer();
            Employee managerAsistant = new ManagerAsistant();
            Employee manager=new Manager();
            Employee areaManager=new AreaManager();

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaManager);

            treasurer.ProcessRequest(p);
               
            return View();
        }
    }
}
