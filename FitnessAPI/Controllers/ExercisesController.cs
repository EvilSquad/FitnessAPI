using Microsoft.AspNetCore.Mvc;
using FitnessAPI.Models;
using FitnessAPI.Clients;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace FitnessAPI.Controllers {
    [ApiController]
    [Route("exercises")]
    public class ExercisesController : ControllerBase {
        private readonly ILogger<ExercisesController> _logger;
        ExercisesClient client = new ExercisesClient();
        public ExercisesController(ILogger<ExercisesController> logger) {
            _logger = logger;
        }
        [HttpGet("muscle/{muscle}")]
        public List<Exercise> GetExerciseByMuscle(string muscle) {
            return client.GetExercise($"?muscle={muscle}").Result;
        }
       
        [HttpGet("type/{type}")]
        public List<Exercise> GetExerciseByType(string type) {
            return client.GetExercise($"?type={type}").Result;
        }

        [HttpGet("difficulty/{difficulty}")]
        public List<Exercise> GetExerciseByDifficulty(string difficulty) {
            return client.GetExercise($"?difficulty={difficulty}").Result;
        }

        [HttpGet("name/{name}")]
        public List<Exercise> GetExerciseByName(string name) {
            return client.GetExercise($"?name={name}").Result;
        }
    }
}


