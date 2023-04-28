﻿namespace Bulky_Models.ViewModels
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;


    public class ProductVM
    {
        public Product Product { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
