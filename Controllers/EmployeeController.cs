using Attendleave.Erp.Core.APIUtilities;
using Attendleave.Erp.Core.UnitOfWork;
using DataLayer.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingProgram.Dtos;
using TestingProgram.Parameter;

namespace TestingProgram.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        private readonly IUnitOfWork<Employee> _unitOfWorkEmployee;
        private readonly IRepositoryActionResult _repositoryActionResult;
        //private readonly IActionResultResponseHandler _actionResultResponseHandler;
        public EmployeeController(
             IUnitOfWork<Employee> unitOfWorkEmployee,
             IActionResultResponseHandler actionResultResponseHandler,
             IHttpContextAccessor httpContextAccessor,
             IRepositoryActionResult repositoryActionResult)
            : base(actionResultResponseHandler, httpContextAccessor)
        {
            _unitOfWorkEmployee = unitOfWorkEmployee;
            _repositoryActionResult = repositoryActionResult;
            //   _actionResultResponseHandler = actionResultResponseHandler;
        }
        [AllowAnonymous]
        [HttpPost(nameof(AddEmployee))]
        public async Task<IRepositoryResult> AddEmployee([FromBody] EmployeeParameter employee)
        {
            try
            {
                var emp = new Employee();
                emp.Name = employee.Name;
                emp.Adress = employee.Address;
                _unitOfWorkEmployee.Repository.Add(emp);
                var result = await _unitOfWorkEmployee.SaveChanges() > 0;
                if (result)
                {
                    var repositoryResult = _repositoryActionResult.GetRepositoryActionResult(emp.Id, status: RepositoryActionStatus.Created, message: "Saved Successfully");
                    var result2 = HttpHandeller.GetResult(repositoryResult);
                    return result2;
                }
                else
                {
                    var repositoryResult = _repositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.Error, message: "لم يتم الحفظ");
                    var result2 = HttpHandeller.GetResult(repositoryResult);
                    return result2;
                }
            }
            catch (Exception e)
            {
               // return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: ResponseActionMessages.Error, status: RepositoryActionStatus.Error);
                var repositoryResult = _repositoryActionResult.GetRepositoryActionResult(exception: e, message: ResponseActionMessages.Error, status: RepositoryActionStatus.Error);
                var result = HttpHandeller.GetResult(repositoryResult);
                return result;
            }

        }
        [AllowAnonymous]
        [HttpGet("GetEmployee/{EmployeeId}")]
        public async Task<IRepositoryResult> GetEmployee(int EmployeeId)
        {
            var employee = await _unitOfWorkEmployee.Repository.FirstOrDefault(q => q.Id == EmployeeId);
            if (employee == null)
            {
                var repositoryResult2 = _repositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NotFound, message: "Not Found");
                var result2 = HttpHandeller.GetResult(repositoryResult2);
                return result2;
            }
            var empDto = new EmployeeDto();
            empDto.Id = employee.Id;
            empDto.Name = employee.Name;
            empDto.Address = employee.Adress;

            var repositoryResult = _repositoryActionResult.GetRepositoryActionResult(empDto, status: RepositoryActionStatus.Ok);
            var result = HttpHandeller.GetResult(repositoryResult);
            return result;
        }
    }
}
