using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.Web.Models
{
    public class Libs
    {
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Input Required")]
        public string InputOne { get; set; }

        [Required(ErrorMessage = "Input Required")]
        public string InputTwo { get; set; }

        [Required(ErrorMessage = "Input Required")]
        public string InputThree { get; set; }

        [Required(ErrorMessage = "Input Required")]
        public string InputFour { get; set; }

        [Required(ErrorMessage = "Input Required")]
        public string InputFive { get; set; }

        public int responseId { get; set; }
    }
}