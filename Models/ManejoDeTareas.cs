using EspacioTareas;
using EspacioAccesoADatos;

namespace EspacioManejoDeTareas;

public class ManejoDeTareas
{
    private AccesoADatos accesoADatos;

    public ManejoDeTareas(AccesoADatos accesoADatos)
    {
        this.accesoADatos = accesoADatos;
    }

    public bool AgregarTarea(Tarea tareaNueva)
    {
        List<Tarea> tareas = accesoADatos.LeerTareas();
        tareas.Add(tareaNueva);
        tareaNueva.Id = tareas.Count();
        bool control = accesoADatos.Guardar(tareas);

        if (control)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public Tarea ObtenerTarea(int idTarea)
    {
        List<Tarea> tareas = accesoADatos.LeerTareas();
        Tarea tareaBuscada = tareas.FirstOrDefault(t => t.Id == idTarea);

        if (tareaBuscada != null)
        {
            return tareaBuscada;
        } else
        {
            return null;
        }
    }

    public bool ActualizarTarea(Tarea tareaModificada)
    {
        List<Tarea> tareas = accesoADatos.LeerTareas();
        Tarea tarea = tareas.FirstOrDefault(t => t.Id == tareaModificada.Id);
        tarea = tareaModificada;
        bool control = accesoADatos.Guardar(tareas);

        if (control)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool EliminarTarea(int idTarea)
    {
        List<Tarea> tareas = accesoADatos.LeerTareas();
        Tarea tarea = tareas.FirstOrDefault(t => t.Id == idTarea);
        
        bool control = tareas.Remove(tarea); 
        accesoADatos.Guardar(tareas);

        if (control)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public List<Tarea> GetTareas()
    {
        return accesoADatos.LeerTareas();
    }

    public List<Tarea> GetTareasCompletadas()
    {
        List<Tarea> tareas = accesoADatos.LeerTareas();
        List<Tarea> tareasCompletadas = tareas.FindAll(t => t.Estado == Estado.Completada);
        
        if (tareasCompletadas != null)
        {
            return tareasCompletadas;
        } else
        {
            return null;
        }
    }
    
}