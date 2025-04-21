using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;

namespace CarbonEmissionCalculator.Application.Bases
{
    public class BaseHandler
    {
        public readonly ICustomMapper customMapper;
        public readonly IUnitOfWork unitOfWork;

        public BaseHandler(ICustomMapper customMapper, IUnitOfWork unitOfWork)
        {
            this.customMapper = customMapper;
            this.unitOfWork = unitOfWork;
        }
    }
}
