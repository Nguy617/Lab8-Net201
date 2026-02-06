using Microsoft.AspNetCore.Mvc;
using Lab6.Services.Interfaces;

public class ReservationController : Controller
{
    private readonly IReservationService _service;

    public ReservationController(IReservationService service)
    {
        _service = service;
    }

    // ===== INDEX =====
    public IActionResult Index()
    {
        var data = _service.GetAll();
        return View(data);
    }

    // ===== CREATE =====
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Reservation r)
    {
        _service.Add(r);
        return RedirectToAction("Index");
    }

    // ===== EDIT =====
    public IActionResult Edit(int id)
    {
        var r = _service.GetById(id);
        if (r == null) return NotFound();
        return View(r);
    }

    [HttpPost]
    public IActionResult Edit(Reservation r)
    {
        _service.Update(r);
        return RedirectToAction("Index");
    }

    // ===== DELETE =====
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}
