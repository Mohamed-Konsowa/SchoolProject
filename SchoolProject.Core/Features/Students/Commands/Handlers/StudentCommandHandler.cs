using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler
                                       , IRequestHandler<AddStudentCommand, Response<string>>
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
            if (result == "Exist") return UnprocessableEntity<string>();
            else if (result == "Success") return Created<string>("Add successfully");
            else return BadRequest<string>();
        }
        #endregion
    }
}
