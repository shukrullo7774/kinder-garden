using Application.Common.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.Queries.GetStudentQueri
{
    public class GetStudentInfoVm : IMapWith<Student>
    {
        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Grades { get; set; }
        public int GroupId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, GetStudentInfoVm>()
                .ForMember(studentVm => studentVm.Firstame,
                opt => opt.MapFrom(Student => Student.Firstame))
                .ForMember(studentVm => studentVm.Lastname,
                opt => opt.MapFrom(Student => Student.Lastname))
                .ForMember(studentVm => studentVm.PhoneNumber,
                opt => opt.MapFrom(Student => Student.PhoneNumber))
                .ForMember(studentVm => studentVm.Login,
                opt => opt.MapFrom(Student => Student.Login))
                .ForMember(studentVm => studentVm.Password,
                opt => opt.MapFrom(Student => Student.Password))
                .ForMember(studentVm => studentVm.Grades,
                opt => opt.MapFrom(Student => Student.Grades))
                .ForMember(studentVm => studentVm.GroupId,
                opt => opt.MapFrom(Student => Student.GroupId));
        }
    }
}
