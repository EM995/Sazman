using Microsoft.AspNetCore.Mvc;
using Sazman.API.Dao;
using Sazman.DataModels.Models;
using System.Data.Entity.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sazman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IDaoWrapper _dao;

        public PersonnelController(IDaoWrapper dao)
        {
            _dao = dao;
        }

        // GET: api/<PersonnelController>
        [HttpGet(Name = "AllPersonnel")]
        public IEnumerable<PersonnelEntity> GetAllPersonnel()
        {
            var personnel = _dao.PersonnelDao.GetAllPersonnel();
            return personnel;
        }

        // GET api/<PersonnelController>/5
        [HttpGet("{id}", Name = "PersonnelById")]
        public ActionResult<PersonnelEntity> GetPersonnelById(Guid id)
        {
            var personnel = _dao.PersonnelDao.GetPersonnelById(id);

            if (personnel is null)
                return NotFound();
            else
                return Ok(personnel);
        }

        // POST api/<PersonnelController>
        [HttpPost]
        public IActionResult CreatePersonnel([FromBody] PersonnelEntity personnel)
        {
            if (personnel is null)
                return BadRequest("Personnel object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            _dao.PersonnelDao.CreatePersonnel(personnel);
            _dao.Save();

            return CreatedAtRoute("PersonnelById", new { id = personnel.Id }, personnel);
        }

        // PUT api/<PersonnelController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePersonnel(Guid id, [FromBody] PersonnelEntity personnel)
        {

            if (personnel is null)
                return BadRequest("Personnel object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid object model");

            var personnelToUpdate = _dao.PersonnelDao.GetPersonnelById(id);
            if (personnelToUpdate is null)
                return NotFound();

            _dao.PersonnelDao.UpdatePersonnel(personnel);
            _dao.Save();

            return Ok();

        }

        // DELETE api/<PersonnelController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePersonnel(Guid id)
        {
            var personnelToDelete = _dao.PersonnelDao.GetPersonnelById(id);
            if (personnelToDelete is null)
                return NotFound();
            _dao.PersonnelDao.DeletePersonnel(personnelToDelete);
            _dao.Save();

            return Ok();

        }
    }
}
