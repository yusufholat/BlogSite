using BlogSite.Entities.Dtos;
using BlogSite.Mvc.Areas.Admin.Models;
using BlogSite.Services.Abstract;
using BlogSite.Shared.Utilities.Extensions;
using BlogSite.Shared.Utilities.Results.ComplexTypes;
using BlogSite.Shared.Utilities.Results.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogSite.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) { 
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll(); 
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, "ziroo");
                if(result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);
        }
    }
}
