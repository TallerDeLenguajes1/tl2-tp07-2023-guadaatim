using EspacioManejoDeTareas;
using EspacioTareas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TareasController;

[ApiController]
[Route("[controller]")]

public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> logger;
    private ManejoDeTareas manejoDeTareas;

    public TareasController(ILogger<TareasController> logger)
    {
        this.logger = logger;
        manejoDeTareas = new ManejoDeTareas();
    }

    [HttpPost("AddTarea")]
    public ActionResult<Tarea> AddTarea(Tarea tareaNueva)
    {
        bool control = manejoDeTareas.AgregarTarea(tareaNueva);

        if (control)
        {
            return Ok(tareaNueva); 
        } else
        {
            return BadRequest();
        }
    }

    [HttpGet("ObtenerTarea")]
    public ActionResult<Tarea> ObtenerTarea(int idTarea)
    {
        Tarea tareaBuscada = manejoDeTareas.ObtenerTarea(idTarea);

        if (tareaBuscada != null)
        {
            return Ok(tareaBuscada);
        } else
        {
            return BadRequest();
        }
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea tareaModificada)
    {
        bool control = manejoDeTareas.ActualizarTarea(tareaModificada);

        if (control)
        {
            return Ok(tareaModificada);
        } else
        {
            return BadRequest();
        }
    }   

    [HttpPost("EliminarTarea")]
    public ActionResult<Tarea> EliminarTarea(int idTarea)
    {
        bool control = manejoDeTareas.EliminarTarea(idTarea);
        
        if (control)
        {
            return Ok();
        } else
        {
            return BadRequest();
        }
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        List<Tarea> tareas = manejoDeTareas.GetTareas();

        if (tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return BadRequest();
        }

    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        List<Tarea> tareasCompletadas = manejoDeTareas.GetTareasCompletadas();

        if (tareasCompletadas != null)
        {
            return Ok(tareasCompletadas);
        } else
        {
            return BadRequest();
        }
    }

}