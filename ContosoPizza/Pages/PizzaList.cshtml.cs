using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        [BindProperty] //用于将 NewPizza 属性绑定到 Razor 页面
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;            
        }
        
        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);
            return RedirectToAction("Get");
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null) 
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToAction("Get");
            //将用户重定向到 Get 页面处理程序，该处理程序将重新呈现包含更新的披萨列表的页面。
        }

    }
}
