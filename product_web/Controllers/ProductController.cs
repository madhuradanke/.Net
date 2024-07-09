using BOL;
using Microsoft.AspNetCore.Mvc;
using SL;

namespace product_web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            //List<BOL.Product> products = _productService.GetAll();
            //return Json(products);
            return View();
            //ViewData["catalog"] = products;
            // return View(products);
        }

        public IActionResult Products()
        {
            List<Product> products = _productService.GetAll();
            ViewData["catalog"] = products;
            return View();
            // return Json(products);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(string? pname, int quantity, double price)
        {
            // double prc = double.Parse(price);
           //int qty1 = int.Parse(quantity);
            Product product = new Product(pname, quantity, price);
            _productService.Insert(product);
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int pid,string? pname,int qty,double price)
        {
            Product product=new Product(pid,pname,qty,price);
            _productService.Update(product);
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int pid)
        {
            _productService.Delete(pid);
            return View();
        }
       /* [HttpGet]
        public IActionResult GetById()
        {
            return View();
        }
       */
        [HttpGet]
        public IActionResult GetById(int id)
        {
            Product product=_productService.GetById(id);
            //ViewData["prod"]=product;
            if
                 (product == null)
            {
                return NotFound();
            }
            else
            {
                return Json(product);
            }
        }

    }
}
