using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Treinamentos.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categorias")]
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
