using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler
                                       , IRequestHandler<AddStudentCommand, Response<string>>
                                       , IRequestHandler<EditStudentCommand, Response<string>>
                                       , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);
            if (result == "Success") return Created<string>("Add successfully");
            else return BadRequest<string>();
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentService.GetByIDAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //mapping Between request and student
            var studentmapper = _mapper.Map(request, student);
            //Call service that make Edit
            var result = await _studentService.EditAsync(studentmapper);
            //return response
            if (result == "Success") return Success("Edit succeded");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentService.GetByIDAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion
    }
}
