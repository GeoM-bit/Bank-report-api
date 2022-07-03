using AutoMapper;
using BankReport.Logic.DtoModels;

namespace BankReport.Controllers.Mappers
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<TransactionReport,ReportDto>()
      .ForMember(destination => destination.categoryName,
                 opt => opt.MapFrom(source => Enum.GetName(typeof(CategoryTransaction),
                 source.categoryName)));
        }
    }
}
