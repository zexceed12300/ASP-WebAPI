using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTXYZ_WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PTXYZ_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SewaController : ControllerBase
    {
        // GET: api/<SewaController>
        [HttpGet]
        public ActionResult<TblSewa> Get()
        {
            using (PtxyzContext context = new PtxyzContext()) 
            {
                if (context.TblLapangans.IsNullOrEmpty())
                    return NoContent();

                return Ok(context.TblSewas.ToList());
            }
        }

        // GET api/<SewaController>/5
        [HttpGet("{id}")]
        public ActionResult<TblSewa> Get(int id)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                if (context.TblLapangans.IsNullOrEmpty())
                    return NoContent();

                var sewa = context.TblSewas.Find(id = id);
                if (sewa == null)
                    return NotFound();

                return Ok(sewa);
            }
        }

        // POST api/<SewaController>
        [HttpPost]
        public ActionResult<TblSewa> Post(TblSewa req)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                var lapangan = context.TblLapangans.Find(req.IdLapangan);
                if (lapangan == null)
                    return NotFound();

                context.TblSewas.Add(req);
                context.SaveChanges();
                return Created("Data created!", req);
            }
        }

        // PUT api/<SewaController>/5
        [HttpPut("{id}")]
        public ActionResult<TblSewa> Put(int id, TblSewa req)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                var sewa = context.TblSewas.Find(req.IdTransaksi);
                if (sewa == null)
                    return NotFound("IdLapangan not found!");

                var lapangan = context.TblLapangans.Find(req.IdLapangan);
                if (lapangan == null)
                    return NotFound("IdLapangan not found!");

                sewa.NoTransaksi = req.NoTransaksi;
                sewa.TglTransaksi = req.TglTransaksi;
                sewa.TotalBayar = req.TotalBayar;
                sewa.LamaSewa = req.LamaSewa;
                sewa.IdLapangan = req.IdLapangan;

                context.SaveChanges();

                return Accepted(sewa);

            }
        }

        // DELETE api/<SewaController>/5
        [HttpDelete("{id}")]
        public ActionResult<TblSewa> Delete(int id)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                var sewa = context.TblSewas.Find(id);
                if (sewa == null)
                    return NotFound();

                context.TblSewas.Remove(sewa);
                context.SaveChanges();
                return Accepted();
            }
        }
    }
}
