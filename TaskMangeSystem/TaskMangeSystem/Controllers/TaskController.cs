using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMangeSystem.Models;
using TaskMangeSystem.Models.viewModel;

namespace TaskMangeSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly appdbcontext _context;
        public TaskController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
            
        }



        public async Task<ActionResult> Edit12(int id)
        {
            var n = await _context.tasks.FirstOrDefaultAsync(u=>u.id == id);
            var mo = await _context.projects.ToListAsync();
            var ni = await _context.teamMembers.ToListAsync();
            Taskviewmodel model = new Taskviewmodel()
            {

               
                Title= n.Title,
                Description= n.Description,
                Deadline= n.Deadline,
                Priority= n.Priority,
                status=n.status,
                projects = mo,
                teams = ni
            };
      


            return View(model);

        }

        // POST: TaskController/Edit/5
        [HttpPost]

        public async Task<IActionResult> Edit12(int id, Taskviewmodel model)
        {
            var mo = await _context.tasks.FirstOrDefaultAsync(i => i.id == id);
            mo.id = model.id;
            mo.Description = model.Description;
            mo.Title = model.Title;
            mo.Priority = model.Priority;
            mo.ProjectId = model.ProjectId;
            mo.TeamMemberid = model.TeamMemberid;
            mo.Deadline = model.Deadline;
            mo.status= model.status;

            _context.tasks.Update(mo);
         await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Project");


        }
    }
}
