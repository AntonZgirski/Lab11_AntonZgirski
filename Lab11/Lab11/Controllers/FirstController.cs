using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab11.Controllers
{
  public class FirstController : Controller
  {    
    private readonly IWebHostEnvironment _webhost;

    public FirstController(IWebHostEnvironment webhost)
    {      
      _webhost = webhost;
    }

    public IActionResult HomePage()
    {
      return View();
    }

    public IActionResult Info()
    {      
      ViewData["Name"] = $"Anton Zgirski";     
      ViewData["Dat"] = DateTime.Now.ToString();
      ViewData["Envi"] = _webhost.EnvironmentName;
      ViewData["App"] = _webhost.ApplicationName;
      ViewData["Host"] = Request.Host;
      ViewData["Prot"] = Request.Protocol;
      return View();
    }

    public IActionResult JsonText()
    {
      var p = new People("Anton","Zgirski","26");
      string js = JsonConvert.SerializeObject(p);
      ViewBag.js = js;  
      return View();
    }

    public IActionResult SetResult(int? index, string name, char ch)
    {
      ViewBag.Result = $"index: {index}, name: {name}, char: {ch}";
      return View();
    }
  }

  [Serializable]
  public class People
  {
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Age { get; set; }
    public People(string fname, string sname, string age)
    {
      FirstName = fname;
      SecondName = sname;
      Age = age;
    }
  }

}
