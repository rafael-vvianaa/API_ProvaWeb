using ApiProvaWeb.Models;
using ApiProvaWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProvaWeb.Controllers
{
    [ApiController]
    [Route("api/v1/Funcionario")]
    [ApiVersion("1.0")]
    public class FuncionarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Funcionario>> Post(
            [FromBody] Funcionario model,
            [FromServices] DataContext context)
        {
            if (ModelState.IsValid)
            {
                model.Funcionarios.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
