using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        //private IServiceGateway<Employee> _em = new GenericDllFacade().GetEmployeeManager();
        //// GET: Employee
        //public ActionResult Index()
        //{
        //    List<Employee> emps = _em.Get();
        //    return View(emps);
        //}

        //[HttpPost]
        //public ActionResult CreateChild(Employee em)
        //{
        //    _em.CreateChild(em);
        //    return RedirectToAction("Index");
        //}


        //[ActionName("Single")]
        //public string Id(int id)
        //{
        //    var person = _em.Get().FirstOrDefault(x => x.Id == id);
        //    return person != null ? person.Id + " " + person.Name : "Not found";
        //}

        //[ActionName("First")]
        //public string GetFirst(int count)
        //{
        //    if (count <= 0) return "Count must be above 0";
        //    if (count > _em.Get().Count)
        //    {
        //        return GetStringPrint(_em.Get());
        //    }
        //    var persons = _em.Get().GetRange(0, count);
        //    return GetStringPrint(persons);
        //}

        //[ActionName("Sorted")]
        //public string GetSorted(bool? desc)
        //{
        //    if (desc.HasValue && desc.Value)
        //    {
        //        return GetStringPrint(_em.Get().OrderByDescending(x => x.Name).ToList());
        //    }
        //    return GetStringPrint(_em.Get().OrderBy(x => x.Name).ToList());
        //}

        //[ActionName("Paged")]
        //public string GetPaged(int page, int itemsPrPage, bool desc)
        //{
        //    if (page <= 0 || itemsPrPage <= 0 || ((page - 1) * itemsPrPage) > _em.Get().Count)
        //    {
        //        return "Bad, page must be above 0 and itemsprpage must be above 0";
        //    }
        //    var pagedList = _em.Get()
        //      .Skip((page - 1) * itemsPrPage)
        //      .Take(itemsPrPage);
        //    if (desc)
        //    {
        //        return GetStringPrint(pagedList.OrderByDescending(x => x.Name).ToList());
        //    }
        //    return GetStringPrint(pagedList.OrderBy(x => x.Name).ToList());
        //}



        //private string GetStringPrint(IEnumerable<Employee> empl)
        //{
        //    var personList = "";
        //    foreach (var person in empl)
        //    {
        //        personList += "<div style='overflow: hidden; white-space: nowrap; '>" +
        //                "<p style='color:darkblue'>" + person.Name + " - " + person.Id + "</p>" +
        //            "</div>";
        //    }
        //    return personList;
        //}


    }
}