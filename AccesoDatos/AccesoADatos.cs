using System.Text.Json;
using EspacioTareas;


namespace EspacioAccesoADatos;

public class AccesoADatos
{
    public List<Tarea> LeerTareas()
    {
        string? jsonString = File.ReadAllText("Tareas.json");
        List<Tarea>? listadoTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
        
        if (listadoTareas != null)
        {
            return listadoTareas;
        } else
        {
            return null;
        }
    }

    public bool Guardar(List<Tarea> tareas)
    {
        if (tareas != null)
        {
            string listadoTareas = JsonSerializer.Serialize(tareas);
            File.WriteAllText("Tareas.json", listadoTareas);

            if (listadoTareas != null)
            {
                return true;
            } else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }
}