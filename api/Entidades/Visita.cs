using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace api.Entidades
{
    public class Visita
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        
        [StringLength(50)]
        public string Oficial { get; set; }
        
        [StringLength(50)]
        public string Descripcion { get; set; } = string.Empty;

 //public DbGeography UbicacionGeografica { get; set; }

    }
}
