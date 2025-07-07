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

        public DemoService(IDemoRepository demoRepository)
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
                ProposalId = demoDto.ProposalId
            };

            DemoRepository.CreateDemo(newDemo);
            await DemoRepository.SaveAsync();
        }

        public async Task DeleteDemo(int id)
        {
            var existing = await DemoRepository.GetDemoAsync(id);
            if (existing == null)
                throw new DemoNotFoundException(id);

            DemoRepository.DeleteDemo(id);
            await DemoRepository.SaveAsync();
        }

        public async Task<DemoDto> GetDemoById(int id)
        {
            var demo = await DemoRepository.GetDemoAsync(id);
            if (demo == null)
                throw new DemoNotFoundException(id);

            return new DemoDto
            {
                VideoUrl = demo.VideoUrl,
                ProposalId = demo.ProposalId
            };
        }

        public async Task UpdateDemo(int id, DemoDto demoDto)
        {
            var demo = await DemoRepository.GetDemoAsync(id);
            if (demo == null)
                throw new DemoNotFoundException(id);

            demo.VideoUrl = demoDto.VideoUrl;
            demo.ProposalId = demoDto.ProposalId;

            DemoRepository.UpdateDemo(demo);
            await DemoRepository.SaveAsync();
        }
    }
}
