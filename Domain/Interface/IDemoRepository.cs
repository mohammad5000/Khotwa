using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDemoRepository
    {
        public Task<Demo> GetDemoAsync(int id);
        public void CreateDemo(Demo demo);
        public void UpdateDemo(Demo demo);
        public Task DeleteDemo(int id);

    }
}
