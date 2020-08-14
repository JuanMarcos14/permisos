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

        public IActionResult Get() => Ok(db.TiposPermisos.Select(t => new { value = t.Id, text = t.Descripcion }));
    }
}