using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class visitaController : ControllerBase
    {
        private readonly DataContext _context;

        public visitaController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Visita>>> Get()
        {
            return Ok(await _context.visita.ToListAsync());
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<Visita>> Get(int id)
        {
            // var visita = visita.Find(h => h.Id == id);
            var visita = await _context.visita.FindAsync(id);
            if (visita == null)
                return BadRequest("visita no encontrada.");
            return Ok(visita);
        }

        [HttpPost]
        public async Task<ActionResult<List<Visita>>> Addvisita(Visita visita)
        {
            //visita.Add(visita);
            _context.visita.Add(visita);
            await _context.SaveChangesAsync();
            return Ok(await _context.visita.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Visita>> Updatevisita(Visita request)
        {
            //var dbvisita = visita.Find(h => h.Id == request.Id);
            var dbvisita=await _context.visita.FindAsync(request.Id);
            if (dbvisita == null)
                return BadRequest("visita no encontrada.");
            dbvisita.IdCliente = request.IdCliente;
            dbvisita.Oficial = request.Oficial;
            dbvisita.Descripcion = request.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(await _context.visita.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Visita>> Delete(int id)
        {
            //var visita = visita.Find(h => h.Id == id);
            var dbvisita=await _context.visita.FindAsync(id);
            if (dbvisita == null)
                return BadRequest("visita no encontrada.");
            //visita.Remove(visita);
            _context.visita.Remove(dbvisita);
            return Ok(await _context.visita.ToListAsync());
        }


        
    }
}














