using System;
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
                if (string.IsNullOrEmpty(searchTerm))
                {
                    List<Dictionary<string, string>> jobs = JobData.FindAll();
                    ViewBag.columns = ListController.columnChoices;
                    ViewBag.title = "All Jobs";
                    ViewBag.jobs = jobs;
                }
                else
                {

                    
                    List<Dictionary<String, String>> jobs = JobData.FindByValue(searchTerm);
                    ViewBag.columns = ListController.columnChoices;
                    // ViewBag.title = searchTerm;

                    ViewBag.column = searchType;
                    ViewBag.jobs = jobs;
                }
            }
            else


            {
                List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                // ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
                ViewBag.jobs = jobs;
                
            }
            return View("Views/Search/Index.cshtml");


        }
    }
}





     