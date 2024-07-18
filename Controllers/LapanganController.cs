using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTXYZ_WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PTXYZ_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapanganController : ControllerBase
    {
        // GET: api/<LapanganController>
        [HttpGet]
        public ActionResult<TblLapangan> Get()
        {

            using (PtxyzContext context = new PtxyzContext())
            {
                if (context.TblLapangans.IsNullOrEmpty())
                    return NoContent();

                return Ok(context.TblLapangans.ToList());

            }

        }

        // GET api/<LapanganController>/5
        [HttpGet("{id}")]
        public ActionResult<TblLapangan> Get(int id)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                if (context.TblLapangans.IsNullOrEmpty())
                    return NoContent();

                var lapangan = context.TblLapangans.Find(id = id);
                if (lapangan == null)
                    return NotFound();

                return Ok(lapangan);
            }
        }

        // POST api/<LapanganController>
        [HttpPost]
        public ActionResult<TblLapangan> Post(TblLapangan req)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                context.TblLapangans.Add(req);
                context.SaveChanges();
                return Created("Data created", req);
            }
        }

        // PUT api/<LapanganController>/5
        [HttpPut("{id}")]
        public ActionResult<TblLapangan> Put(int id, TblLapangan req)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                var lapangan = context.TblLapangans.Find(id = id);
                if (lapangan == null)
                    return NotFound();

                lapangan.NamaLapangan = req.NamaLapangan;
                lapangan.KodeLapangan = req.KodeLapangan;
                context.SaveChanges();

                return Accepted();
            }
        }

        // DELETE api/<LapanganController>/5
        [HttpDelete("{id}")]
        public ActionResult<TblLapangan> Delete(int id)
        {
            using (PtxyzContext context = new PtxyzContext())
            {
                var lapangan = context.TblLapangans.Find(id = id);
                if (lapangan == null)
                    return NotFound();

                context.Remove(lapangan);

                return Accepted();
            }
        }
    }
}
