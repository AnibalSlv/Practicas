using Microsoft.AspNetCore.Mvc;

namespace MiApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new[] { "Tarea 1", "Tarea 2" });

        [HttpPost]
        public IActionResult Post([FromBody] string nuevaTarea) => Ok($"Tarea recibida: {nuevaTarea}");
    }

}
