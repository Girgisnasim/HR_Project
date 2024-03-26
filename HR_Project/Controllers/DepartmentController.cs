using HR_Project.DTO;
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public IDepartment dept;
        public DepartmentController(IDepartment deptRepo)
        {
            dept = deptRepo;

        }
        [HttpGet]
         public ActionResult GetAll()
        {
        List<DepartmentDTO> depDTOs = new List<DepartmentDTO>();

        List<Department> dep = dept.GetAll();
        if (dep == null) { return NotFound(); }

        foreach (var department in dep)
        {
            DepartmentDTO depDTO = new DepartmentDTO
            {
                Id = department.Id,
                DeptName = department.Name
             
            };

            depDTOs.Add(depDTO);
        }

        return Ok(depDTOs);
    }

        //public ActionResult GetAll()
        //{
        //    List<Department> dep = dept.GetAll();
        //    if (dep == null) { return NotFound(); }

        //    return Ok(dep);
        //}



        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> GetById(int id)
        {
            Department dep = dept.GetById(id);
            if (dep == null) { return NotFound(); }

            DepartmentDTO depDTO = new DepartmentDTO
            {
                Id = dep.Id,
                DeptName = dep.Name
              
            };

            return Ok(depDTO);
        }

        [HttpGet("name/{name}")]
        public ActionResult<DepartmentDTO> GetByName(string name)
        {
            Department dep = dept.GetByName(name);
            if (dep == null) { return NotFound(); }

            DepartmentDTO depDTO = new DepartmentDTO
            {
                Id = dep.Id,
                DeptName = dep.Name
               
            };

            return Ok(depDTO);
        }




        //[HttpGet("id")]
        //    public ActionResult GetById(int id)
        //    {
        //        Department depId = dept.GetById(id);
        //        if (depId == null) { return NotFound(); }

        //        return Ok(depId);
        //    }

        //    [HttpGet("name")]
        //    public ActionResult GetByName(string name)
        //    {
        //        Department depName = dept.GetByName(name);

        //        if (depName == null) { return NotFound(); }

        //        else { return Ok(depName); }
        //    }


    }
}
