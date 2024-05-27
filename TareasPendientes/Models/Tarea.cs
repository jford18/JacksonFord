namespace TareasPendientes.Models
{
    public class Tarea
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
    }
}
