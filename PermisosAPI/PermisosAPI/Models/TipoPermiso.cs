using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermisosAPI.Models
{
    public class TipoPermiso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Permiso> Permisos { get; set; }
    }
}
