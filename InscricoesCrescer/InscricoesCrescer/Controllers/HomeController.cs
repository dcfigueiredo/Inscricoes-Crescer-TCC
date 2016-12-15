using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace InscricoesCrescer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

            if (expressaoRegex.IsMatch(enderecoEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}