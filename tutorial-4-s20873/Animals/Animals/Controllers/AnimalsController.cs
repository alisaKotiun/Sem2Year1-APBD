using Animals.Models;
using Animals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IDatabaseService _databaseService;

        public AnimalsController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public IActionResult GetAnimals(string orderBy = "Name")
        {
            return Ok(_databaseService.GetAnimals(orderBy));
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            return Ok(_databaseService.CreateAnimal(animal));
        }

        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal(string idAnimal, Animal animal)
        {
            return Ok(_databaseService.UpdateAnimal(idAnimal, animal));
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(string idAnimal)
        {
            return Ok(_databaseService.DeleteAnimal(idAnimal));
        }

    }
}
