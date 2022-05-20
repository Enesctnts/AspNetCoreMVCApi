using AspNetCoreMVCApi_BLL.ContractsBLL;
using AspNetCoreMVCApi_EL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AspNetCoreMVCApi_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        //İşlemlerin sonucunu nasıl geri verecek
        //Ok 200 -->Listeleme
        //Created 201 --> ekleme işlemi
        //NoContent 204 --> güncelleme işlemi
        //NoContent 204 --> silme işlemi

        private readonly IAssignmentService _assignmentService;
        private ILogger<AssignmentController> _logger;

        public AssignmentController(IAssignmentService assignmentService, ILogger<AssignmentController> logger)
        {
            _assignmentService = assignmentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            try
            {
                var list = _assignmentService.GetAll().Data.ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddAssignment(AssignmentVM model)
        {
            try
            {
                var result = _assignmentService.Add(model);
                if (!result.IsSuccess)
                {
                    return Problem(result.Message);
                }
                return Created(result.Message, model);
            }
            catch (Exception ex)
            {

                return Problem("Beklenmedik bir hata oluştu!" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, string description)
        {
            try
            {
                var result = _assignmentService.Update(id, description);
                if (result.IsSuccess==false)
                {
                    return Problem(result.Message);

                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem("Beklenmedik bir hata oluştu!" + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            try
            {
                var result = _assignmentService.Delete(id);
                if (result.IsSuccess == false)
                {
                    return Problem(result.Message);

                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem("Beklenmedik bir hata oluştu!" + ex.Message);
            }
        }

    }
}
