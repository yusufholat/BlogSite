﻿using BlogSite.Entities.Dtos;

namespace BlogSite.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }
        public string CategoryAddPartial {  get; set; }
        public CategoryDto CategoryDto { get; set; }

    }
}
