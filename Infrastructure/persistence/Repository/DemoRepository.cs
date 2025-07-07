using Domain.Interface;
using Domain.Model;
using Infrastructure.persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.persistence.Repository
{
    public class DemoRepository : IDemoRepository
    {
        private readonly DataContext _context;

        public DemoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Demo> GetDemoAsync(int id)
        {
            return await _context.Demos.FindAsync(id);
        }

        public void CreateDemo(Demo demo)
        {
            _context.Demos.Add(demo);
        }

        public void UpdateDemo(Demo demo)
        {
            _context.Demos.Update(demo);
        }

        public async Task DeleteDemo(int id)
        {
            var demo = await GetDemoAsync(id);
            if (demo != null)
            _context.Demos.Remove(demo);
        }

    }
}
