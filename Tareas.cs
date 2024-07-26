
namespace GestionDeTareas

{
        public class Tareas{
            private int tareaID;
            private string descripcion;
            private int duracion;
            EstadoDeTarea estadoDeTarea;
            public int TareaID { get => tareaID; set => tareaID = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
            public int Duracion { get => duracion; set => duracion = value; }
        internal EstadoDeTarea EstadoDeTarea { get => estadoDeTarea; set => estadoDeTarea = value; }

        public Tareas(int id, string description, int duracion)
        {
            TareaID = id;
            Descripcion = description;
            Duracion = duracion;
        }

        public void MarcarRealizado()
        {
            EstadoDeTarea = EstadoDeTarea.Realizado;
        }

        }

    class ControlDeTareas{
        public List<Tareas> crearNTareas(int n)
        {
               List<Tareas> listaTareas = new List<Tareas>();
                var semilla = Environment.TickCount;
                var random = new Random(semilla); 
                for (int i = listaTareas.Count; i <(listaTareas.Count+ n); i++)
                {

                    int duracion = random.Next(10,101); 
                    Console.WriteLine($"\nIngrese la descripcion de la tarea {i+1}");
                    string descripcion = Console.ReadLine();
                    Tareas tarea = new Tareas(i,descripcion,duracion);
                    listaTareas.Add(tarea);
                }
                return listaTareas;
        }

        public void TranferirTareaRealizadaporId(List<Tareas> Pendientes, List<Tareas> Realizados, int id)
        {
            int i = 0;
            while (i < Pendientes.Count && Pendientes[i].TareaID != id)
            {
                i++;
            }
            Tareas TareaATransferir = Pendientes[i];
            TareaATransferir.MarcarRealizado();
            Realizados.Add(TareaATransferir);
            Pendientes.Remove(TareaATransferir);
        }

        public Tareas BuscarTareaPorDescripcion(List<Tareas> Pendientes, string descripcion)
        {
            Tareas TareaBuscada = null;
            foreach (Tareas tarea in Pendientes)
            {
                if(tarea.Descripcion == descripcion)
                {
                    TareaBuscada = tarea;
                }
            }
            return TareaBuscada;
        }
}
}
       
