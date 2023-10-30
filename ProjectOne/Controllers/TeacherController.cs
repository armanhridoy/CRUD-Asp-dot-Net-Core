using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOne.DataBase;
using ProjectOne.Models;

namespace ProjectOne.Controllers;

public class TeacherController : Controller
{
    private readonly ApplicationDb _applicationDb;
    public TeacherController(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task<IActionResult> index()
    {
        var data = await _applicationDb.teachers.ToListAsync();
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int Id)
    {
        if (Id == 0)
        {
            return View(new Teacher());
        }
        else
        {
            var data = await _applicationDb.teachers.FindAsync(Id);
            return View(data);
        }
    }

    [HttpPost]

    public async Task<IActionResult> CreateOrEdit(int Id ,Teacher teacher)
    {
        if(Id ==0)
        {
            await _applicationDb.teachers.AddAsync(teacher);
            _applicationDb.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        else
        {
            _applicationDb.Attach(teacher); 
            _applicationDb.Entry(teacher).State = EntityState.Modified;
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(index));
        }
    }
   

    public async Task<IActionResult> Delete(int Id)
    {
        var data = await _applicationDb.teachers.FindAsync(Id);
        if (data == null)
        {
            return null;
        }
        _applicationDb.Remove(data);
       await _applicationDb.SaveChangesAsync();
        return RedirectToAction(nameof(index));
    }
}

