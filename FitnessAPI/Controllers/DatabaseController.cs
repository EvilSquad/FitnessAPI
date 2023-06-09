using FitnessAPI.Clients;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAPI.Controllers
{
    [ApiController]
    [Route("database")]
    public class DatabaseController : ControllerBase {
        private readonly ILogger<DatabaseController> _logger;
        public DatabaseController(ILogger<DatabaseController> logger) {
            _logger = logger;
        }

        Database exercises = new Database();

        [HttpPost("exercises/post")]
        public async Task<IActionResult> PostExercise(Exercise exercise) {
            await exercises.InsertExerciseAsync(exercise);
            return Ok();
        }

        [HttpDelete("exercises/delete/{userID}/{id}")]
        public async Task<IActionResult> DeleteExercise(int id, long userID) {
            await exercises.DeleteExerciseByIdAsync(id, userID);
            return Ok();

        }

        [HttpPut("exercises/insert")]
        public async Task<IActionResult> PutExercise(Exercise exercise) {
            await exercises.PutExerciseAsync(exercise);
            return Ok();
        }

        [HttpGet("exercises/get/{userID}")]
        public Task<List<Exercise>> GetAllExercise(long userID) {
            return exercises.GetAllExerciseAsync(userID);
        }

        [HttpGet("exercises/get/{userID}/{name}")]
        public Task<List<Exercise>> GetExerciseByName(long userID, string name) {
            return exercises.GetExerciseByNameAsync(name, userID);
        }

        [HttpGet("exercises/get/muscle/{userID}/{muscle}")]
        public Task<List<Exercise>> GetExerciseByMuscle(string muscle, long userID) {
            return exercises.GetAllExerciseByMuscleAsync(muscle, userID);
        }

        [HttpGet("exercises/get/difficulty/{userID}/{difficulty}")]
        public Task<List<Exercise>> GetExerciseByDifficulty(string difficulty, long userID) {
            return exercises.GetAllExerciseByDifficultyAsync(difficulty, userID);
        }

        [HttpGet("exercises/get/type/{userID}/{type}")]
        public Task<List<Exercise>> GetExerciseByType(string type, long userID) {
            return exercises.GetAllExerciseByTypeAsync(type, userID);
        }

        [HttpDelete("exercises/delete/name/{userID}/{name}")]
        public async Task<IActionResult> DeleteExerciseByName(string name, long userID) {
            await exercises.DeleteExerciseByNameAsync(name, userID);
            return Ok();

        }
    }
}
