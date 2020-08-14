using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermisosAPI.Models;

namespace PermisosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPermisosController : ControllerBase
    {
        private readonly PermisosContext db = new PermisosContext();

        public IActionResult Get()
        {
            //Por motivos de prueba: este bloque se usará para llenar la tabla maestra de tipos de permisos
            if (db.TiposPermisos.Count() == 0)
            {
                List<TipoPermiso> poblar = new List<TipoPermiso> { 
                    new TipoPermiso {Descripcion = "Enfermedad"},
                    new TipoPermiso {Descripcion = "Asuntos Familiares"},
                    new TipoPermiso {Descripcion = "Diligencias"},
                    new TipoPermiso {Descripcion = "Otros"}
                };

                db.AddRange(poblar);
                db.SaveChanges();
            }
            //

            return Ok(db.TiposPermisos.Select(t => new { value = t.Id, text = t.Descripcion }));
        }
    }
}