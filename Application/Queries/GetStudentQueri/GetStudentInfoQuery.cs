using MediatR;

namespace Application.Queries.GetStudentQueri
{
    public class GetStudentInfoQuery : IRequest<GetStudentInfoVm>
    {
        public GetStudentInfoQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
        public string Firstame { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Grades { get; set; }
        public int GroupId { get; set; }
    }
}
