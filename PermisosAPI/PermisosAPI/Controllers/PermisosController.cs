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
    public class PermisosController : ControllerBase
    {
        private readonly PermisosContext db = new PermisosContext();

        [HttpGet]
        public IActionResult Get() =>  Ok(db.Permisos.Select(p => new { 
                                             p.Id,
                                             p.NombreEmpleado,
                                             p.ApellidosEmpleado,
                                             p.Fecha,
                                             p.TipoPermisoId,
                                             TipoPermiso = p.TipoPermiso.Descripcion }));
        

        [HttpPost]
        public IActionResult Post([FromBody] Permiso permiso)
        {
            if (permiso.Id == 0)
                db.Add(permiso);
            else
                db.Update(permiso);

            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.Remove(db.Permisos.Find(id));
            db.SaveChanges();
            return Ok();
        }
    }
}