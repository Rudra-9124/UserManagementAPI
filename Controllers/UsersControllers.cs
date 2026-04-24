// using Microsoft.AspNetCore.Mvc;
// using UserManagementAPI.Models;

// namespace UserManagementAPI.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UsersController : ControllerBase
//     {
//         private static List<User> users = new List<User>
//         {
//             new User { Id = 1, Name = "Rudra", Email = "rudra@email.com", Age = 20 },
//             new User { Id = 2, Name = "John", Email = "john@email.com", Age = 25 }
//         };

//         [HttpGet]
//         public ActionResult<IEnumerable<User>> GetAll()
//         {
//             return Ok(users);
//         }

//         [HttpGet("{id}")]
//         public ActionResult<User> GetById(int id)
//         {
//             var user = users.FirstOrDefault(x => x.Id == id);
//             if (user == null) return NotFound();

//             return Ok(user);
//         }

//         [HttpPost]
//         public ActionResult<User> Create(User user)
//         {
//             user.Id = users.Max(x => x.Id) + 1;
//             users.Add(user);

//             return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
//         }

//         [HttpPut("{id}")]
//         public IActionResult Update(int id, User updatedUser)
//         {
//             var user = users.FirstOrDefault(x => x.Id == id);
//             if (user == null) return NotFound();

//             user.Name = updatedUser.Name;
//             user.Email = updatedUser.Email;
//             user.Age = updatedUser.Age;

//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             var user = users.FirstOrDefault(x => x.Id == id);
//             if (user == null) return NotFound();

//             users.Remove(user);
//             return NoContent();
//         }
//     }
// }

using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Rudra", Email = "rudra@email.com", Age = 20 },
            new User { Id = 2, Name = "John", Email = "john@email.com", Age = 25 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            try
            {
                user.Id = users.Any() ? users.Max(x => x.Id) + 1 : 1;

                users.Add(user);

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch
            {
                return StatusCode(500, "An error occurred while creating user.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound($"User with ID {id} not found.");

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound($"User with ID {id} not found.");

            users.Remove(user);

            return NoContent();
        }
    }
}