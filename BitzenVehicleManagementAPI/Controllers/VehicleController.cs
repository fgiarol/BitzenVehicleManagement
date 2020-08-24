using BitzenVehicleManagementAPI.DTOs;
using BitzenVehicleManagementAPI.Extensions;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitzenVehicleManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IUser _user;

        public VehicleController(IVehicleService vehicleService, IUser user)
        {
            _vehicleService = vehicleService;
            _user = user;
        }

        [Authorize]
        [HttpGet("GetById/{vehicleId}")]
        public ActionResult<Vehicle> GetById(long vehicleId)
        {
            try
            {
                return Ok(_vehicleService.Get(vehicleId));
            }

            catch (ArgumentException ex)
            {
                return NotFound("Invalid data: " + ex.Message);
            }

            catch (Exception e)
            {
                return BadRequest("An error occured: " + e.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult<List<Vehicle>> GetAll()
        {
            try
            {
                return Ok(_vehicleService.GetAll());               
            }
            
            catch (ArgumentException ex)
            {
                return NotFound("Invalid data: " + ex.Message);
            }

            catch (Exception e)
            {
                return BadRequest("An error occured: " + e.Message);
            }
        }

        [Authorize]
        [HttpPost("Create")]
        public ActionResult<Vehicle> Create([FromBody] VehicleDto vehicleDto)
        {
            try
            {
                var userId = _user.GetUserId();

                var vehicle = new Vehicle
                {
                    Brand = vehicleDto.Brand,
                    Model = vehicleDto.Model,
                    Year = vehicleDto.Year,
                    Plate = vehicleDto.Plate,
                    FuelType = vehicleDto.FuelType,
                    Mileage = vehicleDto.Mileage,
                    UserId = userId,
                    Picture = vehicleDto.Picture,
                    VehicleType = vehicleDto.VehicleType                    
                };

                var result = _vehicleService.Create(vehicle);
                return Ok(result);
            }
            
            catch (ArgumentException ex)
            {
                return NotFound("Invalid data: " + ex.Message);
            }

            catch (Exception e)
            {
                return BadRequest("An error occured: " + e.Message);
            }
        }

        [Authorize]
        [HttpPut("Update/{vehicleId}")]
        public ActionResult<Vehicle> Update(long vehicleId, [FromBody] VehicleDto vehicleDto)
        {
            try
            {
                var vehicle = _vehicleService.Get(vehicleId);
                vehicle.Brand = vehicleDto.Brand;
                vehicle.Model = vehicleDto.Model;
                vehicle.FuelType = vehicleDto.FuelType;
                vehicle.Mileage = vehicleDto.Mileage;
                vehicle.Picture = vehicleDto.Picture;
                vehicle.Plate = vehicleDto.Plate;
                vehicle.Year = vehicleDto.Year;
                vehicle.VehicleType = vehicleDto.VehicleType;

                return Ok(_vehicleService.Update(vehicle));
            }

            catch (ArgumentException ex)
            {
                return NotFound("Invalid data: " + ex.Message);
            }

            catch (Exception e)
            {
                return BadRequest("An error occured: " + e.Message);
            }
        }

        [Authorize]
        [HttpDelete("Delete/{vehicleId}")]
        public ActionResult Delete(int vehicleId)
        {
            try
            {
                _vehicleService.Delete(vehicleId);
                return Ok($"vehicleId {vehicleId} deleted");
            }

            catch (ArgumentException ex)
            {
                return NotFound("Invalid data: " + ex.Message);
            }

            catch (Exception e)
            {
                return BadRequest("An error occured: " + e.Message);
            }
        }
    }
}
