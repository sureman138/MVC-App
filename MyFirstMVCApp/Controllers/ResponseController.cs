using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVCApp.Web.Models;
using MyFirstMVCApp.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IResponseDAL responseDal;

        public ResponseController(IResponseDAL responseDal)
        {
            this.responseDal = responseDal;
        }
        public ActionResult PuzzleOne()
        {
            Libs model = new Libs();

            return View("PuzzleOne", model);
        }

        [HttpPost]
        public ActionResult PuzzleOne(Libs model)
        {
            if(!ModelState.IsValid)
            {
                return View("PuzzleOne", model);
            }
            Libs lib = new Libs();
            lib.responseId = model.responseId;
            lib.Name = model.Name;
            lib.InputOne = model.InputOne;
            lib.InputTwo = model.InputTwo;
            lib.InputThree = model.InputThree;
            lib.InputFour = model.InputFour;
            lib.InputFive = model.InputFive;

            responseDal.CreateLib(lib);

            return View("PuzzleOneResult", lib);

        }

        public ActionResult PuzzleOneResult(int id)
        {
            var result = responseDal.GetLibById(id);
            return View("PuzzleOneResult", result);
        }
        public ActionResult PuzzleTwo()
        {
            Libs model = new Libs();
            return View("PuzzleTwo", model);
        }

        [HttpPost]
        public ActionResult PuzzleTwo(Libs model)
        {
            if (!ModelState.IsValid)
            {
                return View("PuzzleOne", model);
            }
            Libs lib = new Libs();
            lib.responseId = model.responseId;
            lib.Name = model.Name;
            lib.InputOne = model.InputOne;
            lib.InputTwo = model.InputTwo;
            lib.InputThree = model.InputThree;
            lib.InputFour = model.InputFour;
            lib.InputFive = model.InputFive;

            responseDal.CreateLib(lib);

            return View("PuzzleTwoResult", lib);
        }

        public ActionResult PuzzleTwoResult(int id)
        {
            var result = responseDal.GetLibById(id);
            return View("PuzzleTwoResult", result);
        }

        public ActionResult PuzzleThree()
        {
            Libs model = new Libs();
            return View("PuzzleThree", model);
        }
        [HttpPost]
        public ActionResult PuzzleThree(Libs model)
        {
            if (!ModelState.IsValid)
            {
                return View("PuzzleOne", model);
            }
            Libs lib = new Libs();
            lib.responseId = model.responseId;
            lib.Name = model.Name;
            lib.InputOne = model.InputOne;
            lib.InputTwo = model.InputTwo;
            lib.InputThree = model.InputThree;
            lib.InputFour = model.InputFour;
            lib.InputFive = model.InputFive;

            responseDal.CreateLib(lib);

            return View("PuzzleThreeResult", lib);
        }
        public ActionResult PuzzleThreeResult(int id)
        {
            var result = responseDal.GetLibById(id);
            return View("PuzzleThreeResult", result);
        }
    }
}
