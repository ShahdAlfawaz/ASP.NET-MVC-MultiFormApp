using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace ASSignment8.Controllers
{
    public class TestController : Controller
    {
       
        [HttpGet]
        public IActionResult Form1()
        {
            ViewBag.t1 = 0;
            ViewBag.t2 = 0;
            
            return View();
        }
        [HttpPost]
        public IActionResult Form1(int t1, int t2, string b1)
        {
            ViewBag.t1 = t1;
            ViewBag.t2 = t2;
            double res;
            if (b1 == "Max")
                res = Math.Max(t1, t2);

            else if (b1 == "Min")

                res = Math.Min(t1, t2);

            else  res = (t1 + t2) / 2.0;
            ViewBag.res = res;
           

            return View();
        }
        [HttpGet]
        public IActionResult Form2()
        {
            ViewBag.n1 = 0;
            ViewBag.n2 = 0;

            return View();
        }
        [HttpPost]
        public IActionResult Form2(double n1, double n2, int Op)
        {
            double res = 0;
            if (Op == 0)
            {  // ADD
                res = (n1 + n2);
            }
            else if (Op == 1)
            { // Sub
                res = (n1 - n2);
            }
            else if (Op == 2)
            {  // Div
                res = (n1 / n2);
            }
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.res = res;
            return View();
        }
        [HttpGet]
        public IActionResult form3()
        {
            ViewBag.No3List = Enumerable.Range(-1, 30).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult form3(int n1, int n2, int n3)
        {
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n3 = n3;
            int[] numbers = { n1, n2, n3 };
            Array.Sort(numbers);
            double res = numbers[1];

            ViewBag.Result = res;
            ViewBag.No3List = Enumerable.Range(-1, 30).ToList();



            return View();
        }
        [HttpGet]
        public IActionResult Form4()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form4(string name, string pass)
        {
            string status = "";
            if (name == "asp" && pass == "asp")
            {
                status = "valid user";
            }

            else status = "Invalid User (Sorry ☹️) please Try Again";

            ViewBag.name = name;
            ViewBag.pass = pass;
            ViewBag.status = status;
            return View();
        }
        //Form 5+6
        [HttpGet]
        public IActionResult Form5()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form5(double no1, double no2, double no3, string b1)
        {
            double res = 0;
            string oper = "";
            if (b1 == "Max")
            {
                res = Math.Max(no1, Math.Max(no2, no3));
                TempData["res"] = res.ToString();
                TempData["oper"] = "Max";
                return RedirectToAction("form6");

            }
            else if (b1 == "Average")
            {
                res = (no1 + no2 + no3) / 3.0;
                TempData["res"] = res.ToString();
                TempData["oper"] = "Average";
                return RedirectToAction("form6");

            }
            TempData["no1"] = no1;
            TempData["no2"] = no2;
            TempData["no3"] = no3;
            TempData["oper"] = oper;
            return View();
        }
        [HttpGet]
        public IActionResult Form6()
        {

            return View();
        }
        [HttpPost]
        [ActionName("form6")]
        public IActionResult back()
        {
            return RedirectToAction("form5");
        }

      
        //Form7+8
        [HttpGet]
        public IActionResult Form7()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form7(string pName, double price, int count)
        {
            double total = price * count;
            HttpContext.Session.SetString("total", total.ToString());
            HttpContext.Session.SetString("pName", pName);
            HttpContext.Session.SetString("price", price.ToString());
            HttpContext.Session.SetString("count", count.ToString());
            return RedirectToAction("form8");

        }
        [HttpGet]
        public IActionResult Form8()
        {
            ViewBag.total = HttpContext.Session.GetString("total");
            ViewBag.pName = HttpContext.Session.GetString("pName");
            ViewBag.price = HttpContext.Session.GetString("price");
            ViewBag.count = HttpContext.Session.GetString("count");


            return View();
        }
        [HttpPost]
        [ActionName("form8")]
        public IActionResult back8()
        {

            return RedirectToAction("form7");
        }
        //form 9+10+11
        [HttpGet]
        public IActionResult Form9()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Form9(string uName, string pName)
        {
            HttpContext.Session.SetString("uName", uName);
            HttpContext.Session.SetString("pName", pName);

            return RedirectToAction("form10");
        }
        [HttpGet]
        public IActionResult Form10()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Form10(double price, int count)
        {
            double total = price * count;
            TempData["total"] = total.ToString();
            TempData["price"] = price.ToString();
            TempData["count"] = count.ToString();

            return RedirectToAction("form11");
        }
        [HttpGet]
        public IActionResult Form11()
        {
            ViewBag.uName = HttpContext.Session.GetString("uName");
            ViewBag.pName = HttpContext.Session.GetString("pName");

            return View();
        }
        [HttpPost]
        [ActionName("form11")]
        public IActionResult back11()
        {

            return View();
        }
        //form 12 + 13
        [HttpGet]
        public IActionResult Form12()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form12(string dep, int phone, string desc)
        {

            if (dep == "1")
            {
                TempData["dep"] = "IT";

            }
            else if (dep == "2")
            {
                TempData["dep"] = "Pharmacy";
            }
            HttpContext.Session.SetString("phone", phone.ToString());
            CookieOptions obj = new CookieOptions();
            obj.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("desc", desc, obj);
            return RedirectToAction("form13");
        }
        [HttpGet]
        public IActionResult Form13()
        {
            var data = Request.Cookies["desc"];
            ViewBag.desc = data;
            ViewBag.phone = HttpContext.Session.GetString("phone");
            
            return View();
        }
        [HttpPost]
        [ActionName("form13")]
        public IActionResult back13()
        {

            return View();
        }
       
    }
}
