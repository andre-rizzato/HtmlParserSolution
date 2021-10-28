using HtmlParser.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlParser.Models
 {          
    public class InputModel
    {

        [Required(ErrorMessage = "The information to be supplied in this field is mandatory.")]
        [Display(Name = "Site Url")]

        public string Field { get; set; }

        [Display(Name = "Parsing Type")]
        public ParsingTypes? ParsingType { get; set; } 
   

    }

 
}
