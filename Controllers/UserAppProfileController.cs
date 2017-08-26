using System;
using System.Threading.Tasks;
using AutoMapper;
using IOTLabWebApi.Controllers.Resources;
using IOTLabWebApi.Core;
using IOTLabWebApi.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IOTLabWebApi.Controllers
{
    [Route("api/userprofile")]
    [EnableCors("CorsPolicy")]
    public class UserAppProfileController : Controller
    {
        private readonly IUserAppProfileRepository appUserProfileRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserAppProfileController(IUserAppProfileRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.appUserProfileRepo = repo;

        }

        /// <summary>
        /// Get a UserProfile
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns>New Created userprofile</returns>
        /// <response code="200">Returns the  userprofile</response>
        /// <response code="404">Returns 404  If the result is null</response>
        /// <response code="400">Returns 400 error If the request did not pass validation</response>
        [ProducesResponseType(typeof(UserAppProfileResource), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAppProfile(int id)
        {

            if (id == 0 || id < 1)
                return BadRequest("Se necesita un id");

            var profile = await appUserProfileRepo.GetUserAppProfile(id);

            if (profile == null)
                return NotFound();

            var result = mapper.Map<UserAppProfile, UserAppProfileResource>(profile);

            return Ok(result);
        }

        /// <summary>
        /// Get a UserProfile by email
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns>New Created userprofile</returns>
        /// <response code="200">Returns the  userprofile</response>
        /// <response code="404">Returns 404  If the result is null</response>
        /// <response code="400">Returns 400 error If the request did not pass validation</response>
        [ProducesResponseType(typeof(UserAppProfileResource), 200)]
        [HttpGet("check/{email}")]
        public IActionResult GetUserAppProfileByEmail(string email)
        {

            if (email == null)
                return BadRequest("Se necesita email");

            var profile = appUserProfileRepo.GetUserAppProfileByEmail(email);

            if (profile == null)
                return NotFound("No se econtro profile");

            var result = mapper.Map<UserAppProfile, UserAppProfileResource>(profile);
            
            return Ok(result);
        }
        /// <summary>
        /// Creates a UserProfile
        /// </summary>
        /// <remarks>
        /// Todos los parametros son requeridos.
        ///  
        ///     POST /userprofile
        ///     {
        ///        "name": "pepe honguito",
        ///        "email": "pepe.honguito@gmail.com",
        ///        "phonenumber": 2619000000
        ///     }
        /// 
        /// </remarks>
        /// <param name="userProfile"></param>
        /// <returns>New Created userprofile</returns>
        /// <response code="200">Returns the newly created userprofile</response>
        /// <response code="400">Returns 400 error If the request did not pass validation</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserAppProfileResource), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(405)]
        public async Task<IActionResult> CreateProfile([FromBody] UserAppProfileResource profileResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profile = mapper.Map<UserAppProfileResource, UserAppProfile>(profileResource);
            

            if (appUserProfileRepo.Add(profile))
            {
                await unitOfWork.CompleteAsync();
                profile = await appUserProfileRepo.GetUserAppProfile(profile.Id);

                var result = mapper.Map<UserAppProfile, UserAppProfileResource>(profile);

                return Ok(result);
            }
            else{
                return StatusCode(405,"El email que se intenta usar para crear profile ya existe");
            }
        }

    }
}