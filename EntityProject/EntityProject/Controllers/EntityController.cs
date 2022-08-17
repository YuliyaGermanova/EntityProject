using Microsoft.AspNetCore.Mvc;

namespace EntityProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        [HttpPost]
        [Route("AddUser")]
        public async Task Add()
        {
            //return View();
        }
    }
}
