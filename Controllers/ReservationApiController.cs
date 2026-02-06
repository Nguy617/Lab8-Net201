using Lab6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/Reservations")]
[ApiController]
public class ReservationApiController : ControllerBase
{
    private readonly IReservationService _service;

    public ReservationApiController(IReservationService service)
    {
        _service = service;
    }

    // GET: api/reservations
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    // GET: api/reservations/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var r = _service.GetById(id);
        if (r == null) return NotFound();
        return Ok(r);
    }

    // POST: api/reservations
    [HttpPost]
    public IActionResult Create(Reservation r)
    {
        _service.Add(r);
        return Ok(r);
    }

    // PUT: api/reservations/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Reservation r)
    {
        if (id != r.Id) return BadRequest();
        _service.Update(r);
        return NoContent();
    }

    // DELETE: api/reservations/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
