using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;

namespace Northwind.Web.Controllers
{
    public class ClientSide : Controller
    {
        public IRepositoryManager _repositoryManager;

        public ClientSide(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public JsonResult GetTotalProductByCategory()
        {
            var result = _repositoryManager.ProductRepository.GetTotalProductByCategory(false);
            return Json(result);
        }

        // GET: ClientSide
        public IActionResult IndexJS()
        {
            return View();
        }
        // GET: ClientSide
        public IActionResult IndexJQuery()
        {
            return View();
        }
        
        // GET: ClientSide
        public IActionResult IndexChart()
        {

            return View();
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] CategoryForCreateDto categoryForCreateDto)
        {
            var categoryDto = categoryForCreateDto;
            var result = new JsonResult(null)
            {
                Value = "Succeed"
            };
            return Ok(result);
        }
        
    }
}
