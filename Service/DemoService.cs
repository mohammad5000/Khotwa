using Domain.Exceptions;
using Domain.Interface;
using Domain.Model;
using Service.Abstraction;
using Shared.DTO.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DemoService : IDemoService
    {
        private readonly IDemoRepository DemoRepository;
        private readonly IUnitWork _unitWork;
        public DemoService(IDemoRepository demoRepository ,IUnitWork unitWork)
        {
            DemoRepository = demoRepository;
        }

        public async Task CreateDemo(DemoDto demoDto)
        {
            if (demoDto == null)
                throw new Exception("DemoDto cannot be null");       //BadRequestException("DemoDto cannot be null");   

            var newDemo = new Demo
            {
                VideoUrl = demoDto.VideoUrl,
                
            };

            DemoRepository.CreateDemo(newDemo);
            await _unitWork.SaveAsync();
        }

        public async Task DeleteDemo(int id)
        {
            var existing = await DemoRepository.GetDemoAsync(id);
            if (existing == null)
                throw new DemoNotFoundException(id);

            await DemoRepository.DeleteDemo(id);
            await _unitWork.SaveAsync();
        }

        public async Task<DemoDto> GetDemoById(int id)
        {
            var demo = await DemoRepository.GetDemoAsync(id);
            if (demo == null)
                throw new DemoNotFoundException(id);

            return new DemoDto
            {
                VideoUrl = demo.VideoUrl,
                
            };
        }

        public async Task UpdateDemo(int id, DemoDto demoDto)
        {
            var demo = await DemoRepository.GetDemoAsync(id);
            if (demo == null)
                throw new DemoNotFoundException(id);

            demo.VideoUrl = demoDto.VideoUrl;
        

            DemoRepository.UpdateDemo(demo);
            await _unitWork.SaveAsync();
        }
    }
}
