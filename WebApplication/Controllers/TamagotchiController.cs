using System.Web.Mvc;
using WebApplication.TamagotchiService;

namespace WebApplication.Controllers
{
    public class TamagotchiController : Controller
    {
        TamagotchiServiceClient service = new TamagotchiServiceClient();

        public ActionResult Index()
        {
            TamagotchiContract[] list = service.GetTamagotchies();

            return View(list);
        }

        public ActionResult Details(string name)
        {
            TamagotchiContract tamagotchi = service.GetTamagotchiByName(name);

            return View(tamagotchi);
        }
    }
}