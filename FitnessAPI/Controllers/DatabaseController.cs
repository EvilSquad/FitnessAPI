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

        [HttpDelete("exercises/delete/id/{userID}/{id}")]
        public async Task<IActionResult> DeleteExercise(int id, long userID) {
            await exercises.DeleteExerciseByIdAsync(id, userID);
            return Ok();

        }

        [HttpPut("exercises/insert/{userID}/{id}")]
        //public async Task<IActionResult> PutExercise(int id, [FromBody] Exercise exercise, int userID) {
        public async Task<IActionResult> PutExercise(int id, string name, string type, string muscle, string equipment, string difficulty, string instructions, long userID) {
            await exercises.PutExerciseAsync(id, name, type, muscle, equipment, difficulty, instructions, userID);
            return Ok();
        }

        [HttpGet("exercises/get/{userID}")]
        public Task<List<Exercise>> GetAllExercise(long userID) {
            return exercises.GetAllExerciseAsync(userID);
        }

        [HttpGet("exercises/get/id/{userID}/{id}")]
        public Task<List<Exercise>> GetExerciseById(int id, long userID) {
            return exercises.GetExerciseByIdAsync(id, userID);
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
