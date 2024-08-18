using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using PetsCareCore.DTOs.Category;
using PetsCareCore.DTOs.Clinic;
using PetsCareCore.DTOs.ClinicAppointment;
using PetsCareCore.DTOs.Item;
using PetsCareCore.DTOs.Login;
using PetsCareCore.DTOs.Pet;
using PetsCareCore.DTOs.Service;
using PetsCareCore.DTOs.User;
using PetsCareCore.DTOs.WishList;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using PetsCareInfra.Services;

namespace Pets_Care.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IClinicService _clinicService;
        private readonly IClinicAppointmentService _clinicAppointmentService;
        private readonly IItemService _itemService;
        private readonly ILoginService _loginService;
        private readonly IPetService _petService;
        private readonly IServicesService _serviceService;
        private readonly IWishListService _wishListService;

        public UserController(
            IUserService userService,
            ICategoryService categoryService,
            IClinicService clinicService,
            IClinicAppointmentService clinicAppointmentService,
            IItemService itemService,
            ILoginService loginService,
            IPetService petService,
            IServicesService serviceService,
            IWishListService wishListService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _clinicService = clinicService;
            _clinicAppointmentService = clinicAppointmentService;
            _itemService = itemService;
            _loginService = loginService;
            _petService = petService;
            _serviceService = serviceService;
            _wishListService = wishListService;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="createUserDTO">The user data transfer object containing user details.</param>
        /// <response code="200">Returns the newly created user.</response>
        /// <response code="400">If the user data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDTO createUserDTO)
        {
            try
            {
                var user = await _userService.CreateUser(createUserDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <response code="200">Returns a list of users.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <response code="200">Returns the user with the specified ID.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updateUserDTO">The user data transfer object containing updated user details.</param>
        /// <response code="204">Indicates that the user was successfully updated.</response>
        /// <response code="400">If the user data is invalid or the ID does not match.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null || id != updateUserDTO.Id)
            {
                return BadRequest("User data is invalid.");
            }

            try
            {
                var user = await _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                await _userService.UpdateUser(updateUserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <response code="204">Indicates that the user was successfully deleted.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="CategoryDTO">The category data transfer object containing category details.</param>
        /// <response code="200">Returns the newly created category.</response>
        /// <response code="400">If the category data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost("category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO CategoryDTO)
        {
            if (CategoryDTO == null)
            {
                return BadRequest("Category data is null.");
            }

            try
            {
                var category = await _categoryService.AddCategory(CategoryDTO);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <response code="200">Returns a list of categories.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <response code="200">Returns the category with the specified ID.</response>
        /// <response code="404">If the category is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound("Category not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="updateCategoryDTO">The category data transfer object containing updated category details.</param>
        /// <response code="204">Indicates that the category was successfully updated.</response>
        /// <response code="400">If the category data is invalid or the ID does not match.</response>
        /// <response code="404">If the category is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (updateCategoryDTO == null || id != updateCategoryDTO.Id)
            {
                return BadRequest("Category data is invalid.");
            }

            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound("Category not found.");
                }

                await _categoryService.UpdateCategory(updateCategoryDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <response code="204">Indicates that the category was successfully deleted.</response>
        /// <response code="404">If the category is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound("Category not found.");
                }

                await _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new clinic.
        /// </summary>
        /// <param name="ClinicDTO">The clinic data transfer object containing clinic details.</param>
        /// <response code="200">Returns the newly created clinic.</response>
        /// <response code="400">If the clinic data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost("clinic")]
        public async Task<IActionResult> AddClinic([FromBody] ClinicDTO ClinicDTO)
        {
            if (ClinicDTO == null)
            {
                return BadRequest("Clinic data is null.");
            }

            try
            {
                var clinic = await _clinicService.AddClinic(ClinicDTO);
                return Ok(clinic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all clinics.
        /// </summary>
        /// <response code="200">Returns a list of clinics.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("clinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            var clinics = await _clinicService.GetAllClinics();
            return Ok(clinics);
        }

        /// <summary>
        /// Retrieves a clinic by its ID.
        /// </summary>
        /// <param name="id">The ID of the clinic to retrieve.</param>
        /// <response code="200">Returns the clinic with the specified ID.</response>
        /// <response code="404">If the clinic is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("clinic/{id}")]
        public async Task<IActionResult> GetClinic(int id)
        {
            try
            {
                var clinic = await _clinicService.GetClinic(id);
                if (clinic == null)
                {
                    return NotFound("Clinic not found.");
                }
                return Ok(clinic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing clinic.
        /// </summary>
        /// <param name="id">The ID of the clinic to update.</param>
        /// <param name="updateClinicDTO">The clinic data transfer object containing updated clinic details.</param>
        /// <response code="204">Indicates that the clinic was successfully updated.</response>
        /// <response code="400">If the clinic data is invalid or the ID does not match.</response>
        /// <response code="404">If the clinic is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("clinic/{id}")]
        public async Task<IActionResult> UpdateClinic(int id, [FromBody] UpdateClinicDTO updateClinicDTO)
        {
            if (updateClinicDTO == null || id != updateClinicDTO.Id)
            {
                return BadRequest("Clinic data is invalid.");
            }

            try
            {
                var clinic = await _clinicService.GetClinic(id);
                if (clinic == null)
                {
                    return NotFound("Clinic not found.");
                }

                await _clinicService.UpdateClinic(updateClinicDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a clinic by its ID.
        /// </summary>
        /// <param name="id">The ID of the clinic to delete.</param>
        /// <response code="204">Indicates that the clinic was successfully deleted.</response>
        /// <response code="404">If the clinic is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("clinic/{id}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            try
            {
                var clinic = await _clinicService.GetClinic(id);
                if (clinic == null)
                {
                    return NotFound("Clinic not found.");
                }

                await _clinicService.DeleteClinic(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Schedules a new clinic appointment.
        /// </summary>
        /// <param name="createAppointmentDTO">The appointment data transfer object containing appointment details.</param>
        /// <response code="200">Returns the newly created appointment.</response>
        /// <response code="400">If the appointment data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("clinicappointment")]
        public async Task<IActionResult> ScheduleAppointment([FromBody] ClinicAppointmentDTO createAppointmentDTO)
        {
            if (createAppointmentDTO == null)
            {
                return BadRequest("Appointment data is null.");
            }

            try
            {
                var appointment = await _clinicAppointmentService.ScheduleAppointment(createAppointmentDTO);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all clinic appointments.
        /// </summary>
        /// <response code="200">Returns a list of clinic appointments.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _clinicAppointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        /// <summary>
        /// Retrieves a clinic appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to retrieve.</param>
        /// <response code="200">Returns the appointment with the specified ID.</response>
        /// <response code="404">If the appointment is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("clinicappointment/{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            try
            {
                var appointment = await _clinicAppointmentService.GetAppointment(id);
                if (appointment == null)
                {
                    return NotFound("Appointment not found.");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing clinic appointment.
        /// </summary>
        /// <param name="id">The ID of the appointment to update.</param>
        /// <param name="updateAppointmentDTO">The appointment data transfer object containing updated appointment details.</param>
        /// <response code="204">Indicates that the appointment was successfully updated.</response>
        /// <response code="400">If the appointment data is invalid or the ID does not match.</response>
        /// <response code="404">If the appointment is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("clinicappointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateClinicAppointmentDTO updateAppointmentDTO)
        {
            if (updateAppointmentDTO == null || id != updateAppointmentDTO.Id)
            {
                return BadRequest("Appointment data is invalid.");
            }

            try
            {
                var appointment = await _clinicAppointmentService.GetAppointment(id);
                if (appointment == null)
                {
                    return NotFound("Appointment not found.");
                }

                await _clinicAppointmentService.UpdateAppointment(updateAppointmentDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancels a clinic appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to cancel.</param>
        /// <response code="204">Indicates that the appointment was successfully canceled.</response>
        /// <response code="404">If the appointment is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("clinicappointment/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            try
            {
                var appointment = await _clinicAppointmentService.GetAppointment(id);
                if (appointment == null)
                {
                    return NotFound("Appointment not found.");
                }

                await _clinicAppointmentService.CancelAppointment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new item.
        /// </summary>
        /// <param name="createItemDTO">The item data transfer object containing item details.</param>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="400">If the item data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("item")]
        public async Task<IActionResult> AddItem([FromBody] ItemDTO createItemDTO)
        {
            if (createItemDTO == null)
            {
                return BadRequest("Item data is null.");
            }

            try
            {
                var item = await _itemService.AddItem(createItemDTO);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all items.
        /// </summary>
        /// <response code="200">Returns a list of items.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("items")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to retrieve.</param>
        /// <response code="200">Returns the item with the specified ID.</response>
        /// <response code="404">If the item is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            try
            {
                var item = await _itemService.GetItem(id);
                if (item == null)
                {
                    return NotFound("Item not found.");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        /// <param name="id">The ID of the item to update.</param>
        /// <param name="updateItemDTO">The item data transfer object containing updated item details.</param>
        /// <response code="204">Indicates that the item was successfully updated.</response>
        /// <response code="400">If the item data is invalid or the ID does not match.</response>
        /// <response code="404">If the item is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("item/{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItemDTO updateItemDTO)
        {
            if (updateItemDTO == null || id != updateItemDTO.Id)
            {
                return BadRequest("Item data is invalid.");
            }

            try
            {
                var item = await _itemService.GetItem(id);
                if (item == null)
                {
                    return NotFound("Item not found.");
                }

                await _itemService.UpdateItem(updateItemDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <response code="204">Indicates that the item was successfully deleted.</response>
        /// <response code="404">If the item is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("item/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _itemService.GetItem(id);
                if (item == null)
                {
                    return NotFound("Item not found.");
                }

                await _itemService.DeleteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Signs in a user.
        /// </summary>
        /// <param name="loginDTO">The login data transfer object containing login details.</param>
        /// <response code="200">Indicates that the sign-in was successful.</response>
        /// <response code="400">If the login data is null.</response>
        /// <response code="401">If the username or password is incorrect.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Login data is null.");
            }

            try
            {
                var (token, userId) = await _loginService.SignIn(loginDTO);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid username or password.");
                }

                // Return the token and userId in the response
                return Ok(new { Token = token, UserId = userId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Signs out a user.
        /// </summary>
        /// <param name="userId">The ID of the user to sign out.</param>
        /// <response code="200">Indicates that the sign-out was successful.</response>
        /// <response code="404">If the user is not found or not logged in.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("logout/{userId}")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var result = await _loginService.SignOut(userId);
                if (!result)
                {
                    return NotFound(new { message = "User not found or not logged in." });
                }

                return Ok(new { message = "Sign-out successful." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }

        /// <summary>
        /// Adds a new pet.
        /// </summary>
        /// <param name="createPetDTO">The pet data transfer object containing pet details.</param>
        /// <response code="200">Returns the newly created pet.</response>
        /// <response code="400">If the pet data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("pet")]
        public async Task<IActionResult> AddPet([FromBody] CreatePetDTO createPetDTO)
        {
            if (createPetDTO == null)
            {
                return BadRequest("Pet data is null.");
            }

            try
            {
                var pet = await _petService.AddPet(createPetDTO);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all pets.
        /// </summary>
        /// <response code="200">Returns a list of pets.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("pets")]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petService.GetAllPets();
            return Ok(pets);
        }

        /// <summary>
        /// Retrieves a pet by its ID.
        /// </summary>
        /// <param name="id">The ID of the pet to retrieve.</param>
        /// <response code="200">Returns the pet with the specified ID.</response>
        /// <response code="404">If the pet is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("pet/{id}")]
        public async Task<IActionResult> GetPet(int id)
        {
            try
            {
                var pet = await _petService.GetPet(id);
                if (pet == null)
                {
                    return NotFound("Pet not found.");
                }
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing pet.
        /// </summary>
        /// <param name="id">The ID of the pet to update.</param>
        /// <param name="updatePetDTO">The pet data transfer object containing updated pet details.</param>
        /// <response code="204">Indicates that the pet was successfully updated.</response>
        /// <response code="400">If the pet data is invalid or the ID does not match.</response>
        /// <response code="404">If the pet is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("pet/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] UpdatePetDTO updatePetDTO)
        {
            if (updatePetDTO == null || id != updatePetDTO.Id)
            {
                return BadRequest("Pet data is invalid.");
            }

            try
            {
                var pet = await _petService.GetPet(id);
                if (pet == null)
                {
                    return NotFound("Pet not found.");
                }

                await _petService.UpdatePet(updatePetDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a pet by its ID.
        /// </summary>
        /// <param name="id">The ID of the pet to delete.</param>
        /// <response code="204">Indicates that the pet was successfully deleted.</response>
        /// <response code="404">If the pet is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("pet/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            try
            {
                var pet = await _petService.GetPet(id);
                if (pet == null)
                {
                    return NotFound("Pet not found.");
                }

                await _petService.DeletePet(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new service.
        /// </summary>
        /// <param name="createServiceDTO">The service data transfer object containing service details.</param>
        /// <response code="200">Returns the newly created service.</response>
        /// <response code="400">If the service data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("service")]
        public async Task<IActionResult> AddService([FromBody] ServiceDTO createServiceDTO)
        {
            if (createServiceDTO == null)
            {
                return BadRequest("Service data is null.");
            }

            try
            {
                var service = await _serviceService.AddService(createServiceDTO);
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all services.
        /// </summary>
        /// <response code="200">Returns a list of services.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("services")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceService.GetAllServices();
            return Ok(services);
        }

        /// <summary>
        /// Retrieves a service by its ID.
        /// </summary>
        /// <param name="id">The ID of the service to retrieve.</param>
        /// <response code="200">Returns the service with the specified ID.</response>
        /// <response code="404">If the service is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("service/{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            try
            {
                var service = await _serviceService.GetService(id);
                if (service == null)
                {
                    return NotFound("Service not found.");
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing service.
        /// </summary>
        /// <param name="id">The ID of the service to update.</param>
        /// <param name="updateServiceDTO">The service data transfer object containing updated service details.</param>
        /// <response code="204">Indicates that the service was successfully updated.</response>
        /// <response code="400">If the service data is invalid or the ID does not match.</response>
        /// <response code="404">If the service is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("service/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceDTO updateServiceDTO)
        {
            if (updateServiceDTO == null || id != updateServiceDTO.Id)
            {
                return BadRequest("Service data is invalid.");
            }

            try
            {
                var service = await _serviceService.GetService(id);
                if (service == null)
                {
                    return NotFound("Service not found.");
                }

                await _serviceService.UpdateService(updateServiceDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a service by its ID.
        /// </summary>
        /// <param name="id">The ID of the service to delete.</param>
        /// <response code="204">Indicates that the service was successfully deleted.</response>
        /// <response code="404">If the service is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("service/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var service = await _serviceService.GetService(id);
                if (service == null)
                {
                    return NotFound("Service not found.");
                }

                await _serviceService.DeleteService(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds an item to the wishlist.
        /// </summary>
        /// <param name="createWishListDTO">The wishlist data transfer object containing wishlist details.</param>
        /// <response code="200">Returns the newly created wishlist item.</response>
        /// <response code="400">If the wishlist data is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("wishlist")]
        public async Task<IActionResult> AddToWishList([FromBody] WishListDTO createWishListDTO)
        {
            if (createWishListDTO == null)
            {
                return BadRequest("WishList data is null.");
            }

            try
            {
                var wishList = await _wishListService.AddToWishList(createWishListDTO);
                return Ok(wishList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all wishlists.
        /// </summary>
        /// <response code="200">Returns a list of wishlists.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("wishlists")]
        public async Task<IActionResult> GetAllWishLists()
        {
            var wishLists = await _wishListService.GetAllWishLists();
            return Ok(wishLists);
        }

        /// <summary>
        /// Retrieves the wishlist for a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user whose wishlist to retrieve.</param>
        /// <response code="200">Returns the wishlist for the specified user.</response>
        /// <response code="404">If the wishlist is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("wishlist/{userId}")]
        public async Task<IActionResult> GetWishList(int userId)
        {
            try
            {
                var wishLists = await _wishListService.GetWishList(userId);
                return Ok(wishLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing wishlist item.
        /// </summary>
        /// <param name="id">The ID of the wishlist item to update.</param>
        /// <param name="updateWishListDTO">The wishlist data transfer object containing updated wishlist details.</param>
        /// <response code="204">Indicates that the wishlist item was successfully updated.</response>
        /// <response code="400">If the wishlist data is invalid or the ID does not match.</response>
        /// <response code="404">If the wishlist item is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("wishlist/{id}")]
        public async Task<IActionResult> UpdateWishList(int id, [FromBody] UpdateWishListDTO updateWishListDTO)
        {
            if (updateWishListDTO == null || id != updateWishListDTO.Id)
            {
                return BadRequest("WishList data is invalid.");
            }

            try
            {
                var wishList = await _wishListService.GetWishList(id);
                if (wishList == null)
                {
                    return NotFound("WishList not found.");
                }

                await _wishListService.UpdateWishList(updateWishListDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes an item from the wishlist by its ID.
        /// </summary>
        /// <param name="id">The ID of the wishlist item to remove.</param>
        /// <response code="204">Indicates that the wishlist item was successfully removed.</response>
        /// <response code="404">If the wishlist item is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("wishlist/{id}")]
        public async Task<IActionResult> RemoveFromWishList(int id)
        {
            try
            {
                var wishList = await _wishListService.GetWishList(id);
                if (wishList == null)
                {
                    return NotFound("WishList not found.");
                }

                await _wishListService.RemoveFromWishList(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Initiates the password recovery process for the specified email.
        /// </summary>
        /// <param name="recoverPasswordDTO">The DTO containing the email for password recovery.</param>
        /// <response code="200">Indicates that the password reset link was sent successfully.</response>
        /// <response code="404">If the email is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] RecoverPasswordDTO recoverPasswordDTO)
        {
            var result = await _loginService.RecoverPassword(recoverPasswordDTO);
            if (!result)
            {
                return NotFound(new { message = "Email not found." }); // Return structured JSON
            }

            return Ok(new { message = "Password reset link has been sent to your email." }); // Return structured JSON
        }


        /// <summary>
        /// Resets the user's password using the provided token.
        /// </summary>
        /// <param name="resetPasswordDTO">The DTO containing the email, token, and new password.</param>
        /// <response code="200">Indicates that the password was reset successfully.</response>
        /// <response code="400">If the token is invalid or expired.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _loginService.ResetPassword(resetPasswordDTO.Email, resetPasswordDTO.Token, resetPasswordDTO.NewPassword);

            if (result)
            {
                return Ok(new { message = "Password has been reset successfully." }); // Return structured JSON
            }
            else
            {
                return BadRequest(new { message = "Invalid or expired token." }); // Return structured JSON
            }
        }

    }
}
