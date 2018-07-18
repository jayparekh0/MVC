using Data;
using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    [HandleError]
    public class ContractController : Controller
    {
        private IContractService contractService;

        public ContractController(IContractService contService)
        {
            contractService = contService;
        }

        //
        // GET: /Contract/
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ContractModel> model = contractService.GetContracts().Select(u => new ContractModel
            {
                ContractID = u.ContractID,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Phone = u.Phone,
                StatusID = u.Status.StatusID,
                StatusDesc = u.Status.StatusDesc
            });
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateEditContract(int? id)
        {
            ContractModel model = new ContractModel();
            if (id.HasValue && id != 0)
            {
                Contract contractEntity = contractService.GetContract(id.Value);
                model.ContractID = contractEntity.ContractID;
                model.FirstName = contractEntity.FirstName;
                model.StatusDesc= contractEntity.Status.StatusDesc;
                model.StatusID = contractEntity.StatusID;
                model.LastName = contractEntity.LastName;
                model.Email = contractEntity.Email;
                model.Phone = contractEntity.Phone;
            }
            IEnumerable<Status> ies = new List<Status>()
            { new Status(){ StatusID=1, StatusDesc="Active"}, new Status(){ StatusID=2, StatusDesc="Inactive"}};
            ViewBag.StatusID = new SelectList(ies);
            ViewBag.StatusID = new SelectList(ies, "StatusID", "StatusDesc", model.StatusID);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditContract(ContractModel model, string ContID)
        {
            int id = Convert.ToInt32(ContID);
            if (id == 0)
            {
                Contract contractEntity = new Contract
                {
                    FirstName= model.FirstName,
                    StatusID = model.StatusID,
                    LastName = model.LastName,
                    Email =model.Email,
                    Phone = model.Phone
                };
                contractService.InsertContract(contractEntity);
                if (contractEntity.ContractID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                Contract contractEntity = contractService.GetContract(id);
                contractEntity.FirstName = model.FirstName;
                contractEntity.StatusID = model.StatusID;
                contractEntity.LastName = model.LastName;
                contractEntity.Phone = model.Phone;
                contractEntity.Email = model.Email;
                contractService.UpdateContract(contractEntity);
                if (contractEntity.ContractID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            return View(model);
        }
        public ActionResult DetailContract(int? id)
        {
            ContractModel model = new ContractModel();
            if (id.HasValue && id != 0)
            {
                Contract myEntity = contractService.GetContract(id.Value);
                // model.ID = userEntity.ID;
                model.FirstName = myEntity.FirstName;
                model.StatusID = myEntity.StatusID;
                model.StatusDesc = myEntity.Status.StatusDesc;
                model.ContractID = myEntity.ContractID;
                model.LastName = myEntity.LastName;
                model.Phone = myEntity.Phone;
                model.Email = myEntity.Email;
            }
            return View(model);
        }

        public ActionResult DeleteContract(int id)
        {
            ContractModel model = new ContractModel();
            if (id != 0)
            {
                Contract myEntity = contractService.GetContract(id);
                model.FirstName = myEntity.FirstName;
                model.StatusID = myEntity.StatusID;
                model.StatusDesc = myEntity.Status.StatusDesc;
                model.ContractID = myEntity.ContractID;
                model.LastName = myEntity.LastName;
                model.Phone = myEntity.Phone;
                model.Email = myEntity.Email;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult DeleteContract(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    Contract Entity = contractService.GetContract(id);
                    contractService.DeleteContract(Entity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            //Logging the Exception
            filterContext.ExceptionHandled = true;

            //Log error into db... I am making it as async called... As it returns void (fire and forget)
            Action a = new Action(() => { Utility.ErrorSave._getInstance.Log(filterContext.Exception); });
            System.Threading.Tasks.Task.Factory.StartNew(a);

            var Result = this.View("Error", new HandleErrorInfo(exception,
                filterContext.RouteData.Values["controller"].ToString(),
                filterContext.RouteData.Values["action"].ToString()));

            filterContext.Result = Result;

        }
	}
}