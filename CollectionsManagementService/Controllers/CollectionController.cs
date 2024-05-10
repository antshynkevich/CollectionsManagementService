using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

public class CollectionController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        var viewModel = new CreateCollectionViewModel();
        int fieldsIndex = 0;
        var fieldsArray = viewModel.CollectionFields;
        foreach (var fieldType in (FieldType[]) Enum.GetValues(typeof(FieldType)))
        {
            for (int i = 0; i < 3; i++)
            {
                fieldsArray[fieldsIndex] = new CreateCollectionFieldViewModel
                {
                    FieldType = fieldType
                };

                fieldsIndex++;
            }
        }

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateCollectionViewModel viewModel)
    {
        // Process the submitted data (e.g., save to the database)
        // viewModel.Name, viewModel.Description, viewModel.CategoryId, viewModel.CollectionFields, etc.
        // Redirect to another page or return a view
        return RedirectToAction("Index", "Home");
    }
}
