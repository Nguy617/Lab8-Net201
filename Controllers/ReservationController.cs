using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

public class ReservationController : Controller
{
    // Dynamic API URL - works in both local and production

    // ===== INDEX =====
    public async Task<IActionResult> Index()
    {
        HttpClient client = new HttpClient();
        var apiUrl = $"{Request.Scheme}://{Request.Host}/api/Reservations";
        var json = await client.GetStringAsync(apiUrl);
        var data = JsonConvert.DeserializeObject<List<Reservation>>(json);
        return View(data);
    }

    // ===== CREATE =====
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Reservation r)
    {
        HttpClient client = new HttpClient();
        var apiUrl = $"{Request.Scheme}://{Request.Host}/api/Reservations";
        var json = JsonConvert.SerializeObject(r);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync(apiUrl, content);
        return RedirectToAction("Index");
    }

    // ===== EDIT =====
    public async Task<IActionResult> Edit(int id)
    {
        HttpClient client = new HttpClient();
        var apiUrl = $"{Request.Scheme}://{Request.Host}/api/Reservations";
        var json = await client.GetStringAsync($"{apiUrl}/{id}");
        var r = JsonConvert.DeserializeObject<Reservation>(json);
        return View(r);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Reservation r)
    {
        HttpClient client = new HttpClient();
        var apiUrl = $"{Request.Scheme}://{Request.Host}/api/Reservations";
        var json = JsonConvert.SerializeObject(r);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PutAsync($"{apiUrl}/{r.Id}", content);
        return RedirectToAction("Index");
    }

    // ===== DELETE =====
    public async Task<IActionResult> Delete(int id)
    {
        HttpClient client = new HttpClient();
        var apiUrl = $"{Request.Scheme}://{Request.Host}/api/Reservations";
        await client.DeleteAsync($"{apiUrl}/{id}");
        return RedirectToAction("Index");
    }
}
