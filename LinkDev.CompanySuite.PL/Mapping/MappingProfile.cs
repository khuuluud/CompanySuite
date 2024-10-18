using AutoMapper;
using LinkDev.CompanyBase.BLL.Moduls.DTO.Departments;
using LinkDev.CompanyBase.PL.ViewModels.Departments;

namespace LinkDev.CompanyBase.PL.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region Department

            CreateMap<DepartmentDetailsDto, DepartmentViewModel>();
            //.ForMember(dest => dest.Name , config => config.MapFrom(src => src.Name));

            CreateMap<DepartmentViewModel, CreatedDepartmentDto>();




            #endregion

            #region Employee



            #endregion
        }

    }
}
