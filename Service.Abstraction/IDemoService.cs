using Shared.DTO.Category;
using Shared.DTO.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IDemoService
    {
        public Task CreateDemo(DemoDto demoDto);
        public Task<DemoDto> GetDemoById(int id);
        public Task UpdateDemo(int id, DemoDto demoDto);
        public Task DeleteDemo(int id);
    }
}
