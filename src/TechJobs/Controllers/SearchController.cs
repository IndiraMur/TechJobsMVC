using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }


        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            //look up search results via JobData class   
            //if user searches 'all'
            if (searchType.Equals("all"))
            {

                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "All Jobs";
                ViewBag.jobs = JobData.FindAll();

            }
            //if user searches by category
            else

            {

                ViewBag.columns = ListController.columnChoices;
              //  ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType,searchTerm);



            }
            return View("Views/Search/Index.cshtml");
        }






        /*    {
                ViewBag.columns = ListController.columnChoices;
                ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            //pass them into Views/Search/index.cshtml 
            return View("Views/Search/Index.cshtml");
        }*/
    }
}
