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

        [BindProperty] //���ڽ� NewPizza ���԰󶨵� Razor ҳ��
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
            //���û��ض��� Get ҳ�洦����򣬸ô���������³��ְ������µ������б��ҳ�档
        }

    }
}
