using GymApp.Models;
using GymApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly GymManagementContext _context;

        public ProgramRepository(GymManagementContext context)
        {
            _context = context;
        }

        public Models.Program GetById(int id)
        {
            return _context.Programs
                .Include(p => p.Coach)
                .Include(p => p.Classes)
                .FirstOrDefault(p => p.ID == id);
        }

        public List<Models.Program> GetAll()
        {
            return _context.Programs
                .Include(p => p.Coach)
                .Include(p => p.Classes)
                .ToList();
        }

        public void Add(Models.Program entity)
        {
            _context.Programs.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Models.Program entity)
        {
            _context.Programs.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Programs.Find(id);
            if (entity != null)
            {
                _context.Programs.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
