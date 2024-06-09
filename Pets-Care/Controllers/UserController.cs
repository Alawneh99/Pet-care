using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // User operations
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (createUserDTO == null)
            {
                return BadRequest("User data is null.");
            }

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

        // Category operations
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

        // Clinic operations
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

        // Clinic Appointment operations
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

        // Item operations
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

        // Login operations
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Login data is null.");
            }

            try
            {
                var result = await _loginService.SignIn(loginDTO);
                if (!result)
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok("Sign-in successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("logout/{userId}")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var result = await _loginService.SignOut(userId);
                if (!result)
                {
                    return NotFound("User not found or not logged in.");
                }

                return Ok("Sign-out successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("recoverpassword")]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordDTO recoverPasswordDTO)
        {
            if (recoverPasswordDTO == null)
            {
                return BadRequest("Recovery data is null.");
            }

            try
            {
                var result = await _loginService.RecoverPassword(recoverPasswordDTO);
                if (!result)
                {
                    return NotFound("User not found.");
                }

                return Ok("Recovery process initiated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Pet operations
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

        // Service operations
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

        // WishList operations
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
    }
}
