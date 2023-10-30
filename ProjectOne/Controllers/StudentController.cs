using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOne.DataBase;
using ProjectOne.Models;

namespace ProjectOne.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDb _applicationDb;
    public StudentController(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task<IActionResult> index()
    {
        var data =await _applicationDb.students.ToListAsync();
        return View(data);
    }
    public async Task<IActionResult>CreateorEdit( int Id)
    {
        if (Id == 0)
        {
            return View(new Student());
        }
        else
        {
            var data = await _applicationDb.students.FindAsync(Id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(int Id, Student student)
    {
        if (Id == 0)
        {
            await _applicationDb.students.AddAsync(student);
            _applicationDb.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        else
        {
            _applicationDb.Attach(student);
            _applicationDb.Entry(student).State = EntityState.Modified;
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(index));
        }
    }
    public async Task<IActionResult> Delete (int Id)
    {
        var data = await _applicationDb.students.FindAsync(Id);
        if(data== null)
        {
            return null;
        }
        _applicationDb.Remove(data);
        await _applicationDb.SaveChangesAsync();
        return RedirectToAction(nameof(index));
    }
}
