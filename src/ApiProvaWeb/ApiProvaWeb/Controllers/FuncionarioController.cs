using ApiProvaWeb.Models;
using ApiProvaWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                model.DataDeCadastro = DateTime.Now;
                context.Funcionarios.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Funcionario>>> Get([FromServices] DataContext context)
        {
            var funcionarios = await context.Funcionarios.AsNoTracking().ToListAsync();
            return funcionarios;
        }

        [HttpGet]
        [Route("nome")]
        public async Task<ActionResult<Funcionario>> GetByName([FromServices] DataContext context, string nome)
        {
            var funcionarios = await context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.Nome.Contains(nome));
            return funcionarios;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody] Funcionario model)
        {
            
            if (id != model.Id)
                return NotFound(new { message = "id Funcionario não encontrado" });

            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Funcionario>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar o Funcionario" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> Delete(
           [FromServices] DataContext context,
           int id)
        {
            var category = await context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Funcionario não encontrado" });

            try
            {
                context.Funcionarios.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Funcionario" });

            }
        }

    }
}
