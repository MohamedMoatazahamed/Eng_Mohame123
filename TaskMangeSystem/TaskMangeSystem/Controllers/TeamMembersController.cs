using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMangeSystem.Models;

namespace TaskMangeSystem.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly appdbcontext _context;

        public TeamMembersController(appdbcontext context)
        {
            _context = context;
        }

        // GET: TeamMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.teamMembers.ToListAsync());
        }


      
        public async Task<IActionResult> Details(int id)
        {
            var mo = await _context.teamMembers.FirstOrDefaultAsync(x => x.Id == id);
            var op = await _context.tasks.Where(i => i.TeamMemberid == mo.Id).Include(i => i.Project).ToListAsync();
            mo.tasks = op;
            return View(mo);
        }
        

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
       
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
           
                _context.teamMembers.Add(teamMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.teamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        [HttpPost]
    
        public async Task<IActionResult> Edit( TeamMember teamMember)
        {
         
                
                    _context.teamMembers.Update(teamMember);
                    await _context.SaveChangesAsync();
             
                return RedirectToAction("Index", "Project");
            
           
        }


        public async Task<IActionResult> Delete(int id)
        {
           

            var teamMember = await _context.teamMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

     
        [HttpPost]

        public async Task<IActionResult> Delete(TeamMember teamMember)
        {
          
                _context.teamMembers.Remove(teamMember);
            

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Project");
        }

      
    }
}





