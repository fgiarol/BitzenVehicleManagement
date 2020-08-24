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
    public class FuelingController : ControllerBase
    {
        private readonly IFuelingService _fuelingService;
        private readonly IUser _user;

        public FuelingController(IFuelingService fuelingService, IUser user)
        {
            _fuelingService = fuelingService;
            _user = user;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult<List<Fueling>> GetAll()
        {
            try
            {
                return Ok(_fuelingService.GetAll());
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
        [HttpGet("GetById/{fuelingId}")]
        public ActionResult<Fueling> GetById(long fuelingId)
        {
            try
            {
                return Ok(_fuelingService.Get(fuelingId));
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
        public ActionResult<Fueling> Create([FromBody] FuelingDto fuelingDto)
        {
            try
            {
                var userId = _user.GetUserId();

                var fueling = new Fueling
                {
                    FuelingDateTime = fuelingDto.FuelingDateTime,
                    FuelingMileage = fuelingDto.FuelingMileage,
                    FuelStation = fuelingDto.FuelStation,
                    Liters = fuelingDto.Liters,
                    Value = fuelingDto.Value,
                    FuelType = fuelingDto.FuelType,
                    VehicleId = fuelingDto.VehicleId,
                    UserId = userId
                };

                var result = _fuelingService.Create(fueling);
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
        [HttpPut("Update/{fuelingId}")]
        public ActionResult<Fueling> Update(int fuelingId, [FromBody] FuelingDto fuelingDto)
        {
            try
            {
                var fueling = _fuelingService.Get(fuelingId);
                fueling.FuelingDateTime = fuelingDto.FuelingDateTime;
                fueling.FuelingMileage = fuelingDto.FuelingMileage;
                fueling.FuelStation = fuelingDto.FuelStation;
                fueling.FuelType = fuelingDto.FuelType;
                fueling.Liters = fuelingDto.Liters;
                fueling.Value = fuelingDto.Value;
                fueling.VehicleId = fuelingDto.VehicleId;

                return Ok(_fuelingService.Update(fueling));
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
        [HttpDelete("Delete/{fuelingId}")]
        public ActionResult Delete(int fuelingId)
        {
            try
            {
                _fuelingService.Delete(fuelingId);
                return Ok($"fuelingId: {fuelingId} - deleted");
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

