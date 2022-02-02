using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DTOs.Response;
using Test.Models;

namespace Test.Services
{
    public interface IDbService
    {
        public Task<IActionResult> GetActions(int id);
        public Task<IActionResult> AssignFireTruck(int idF, int idA);
    }
    public class MainDbService : IDbService
    {
        private IMainDbContext _context;

        public MainDbService(IMainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetFlights(int id)
        {
            if (!await CheckPassenger(id)) return new NotFoundObjectResult($"Passenger {id} is not found");
            var flights = await _context.FlightsPassengers
                .Where(f => f.IdPassenger == id)
                .OrderByDescending(f => f.Flight.FlightDate)
                .Select(f => new FlightsResponseDTO()
                {
                    City = f.Flight.City.City,
                    Plane = f.Flight.Plane
                })
                .ToListAsync();

            return new OkObjectResult(flights);
        }

        public async Task<IActionResult> RegisterPassenger(int idP, int idF)
        {
            if (!await CheckPassenger(idP)) return new NotFoundObjectResult($"Passenger {idP} is not found");
            if (!await CheckFlight(idF)) return new NotFoundObjectResult($"Flight {idF} is not found");
            if (!await CheckRegisteredPassenger(idP, idF)) return new BadRequestObjectResult($"Passenger {idP} is already registered for flight {idF}");
            if (!await CheckFlightDate(idF)) return new BadRequestObjectResult($"Flight {idF} has already taken place");
            if (!await CheckFlightDate(idF)) return new BadRequestObjectResult($"Flight {idF} has already taken place");



        }


        private async Task<bool> CheckPassenger(int id)
        {
            return await _context.Passengers
                .AnyAsync(p => p.IdPassenger == id); ;
        }

        private async Task<bool> CheckFlight(int id)
        {
            return await _context.Flights
                .AnyAsync(p => p.IdFlight == id); ;
        }

        private async Task<bool> CheckRegisteredPassenger(int idP, int idF)
        {
            return await _context.FlightPassengers
                .AnyAsync(f => f.IdFlight == idF && f.IdPassenger == idP); 
        }

        private async Task<bool> CheckFlightDate(int idF)
        {
            return await _context.Flights
                .Where(f => f.FlightDate > DateTime.Now)
                .AnyAsync(f => f.IdFlight == idF);
        }

        private async Task<bool> CheckSeatsLimit(int idF)
        {
            var maxSeats = await _context.Flights
                .Where(f => f.IdFlight == idF)
                .SingleOrDeafault(f => f.Plane.MaxSeats);

            var currentSeats = await _context.Flight_Passengers
                .Where(f => f.IdFlight == idF)
                .
        }
        -------------------------

        public async Task<IActionResult> GetActions(int id)
        {
            if (!await CheckFighter(id)) return new BadRequestObjectResult($"Firefighter {id} does not exist");

            var actions = await _context.FirefighterActions
                .Where(f => f.IdFirefighter == id)
                .Select(f => new GetActionByFighterResponse()
                {
                    IdAction = f.IdAction,
                    StartDate = f.Action.StartTime,
                    EndDate = f.Action.EndTime
                })
                .OrderByDescending(a => a.EndDate)
                .ToListAsync();


            return new OkObjectResult(actions);
        }

        public async Task<IActionResult> AssignFireTruck(int idF, int idA)
        {
            if (!await CheckFireTruck(idF)) return new BadRequestObjectResult($"FireTruck {idF} does not exist");
            if (!await CheckAction(idA)) return new BadRequestObjectResult($"Action {idA} does not exist");
            if (await CheckFireTruckInUse(idF)) return new BadRequestObjectResult($"FireTruck {idF} is in use");
            if(await CheckEquipment(idF, idA)) return new BadRequestObjectResult($"You need special equipment");


            var truckAction = new FireTruckAction()
            {
                IdAction = idA,
                IdFireTruck = idF,
                AssignmentDate = DateTime.Now
            };

            await _context.FireTruckActions.AddAsync(truckAction);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"Firetruck {idF} was asigned to action {idA}");
        }

        private async Task<bool> CheckEquipment(int idF, int idA)
        {
            var f = await _context.FireTrucks
                .Where(f => f.IdFireTruck == idF)
                .SingleOrDefaultAsync();
            var a = await _context.Actions
                .Where(a => a.IdAction == idA)
                .SingleOrDefaultAsync();

            return f.SpecialEquipment ^ a.NeedSpecialEquipment;
        }

        private async Task<bool> CheckFireTruckInUse(int id)
        {
            return await _context.FireTruckActions
                .Where(f => f.Action.EndTime != null)
                .AnyAsync(f => f.IdFireTruck == id);
        }

        private async Task<bool> CheckAction(int id)
        {
            return await _context.Actions
                .AnyAsync(f => f.IdAction == id);
        }

        private async Task<bool> CheckFireTruck(int id)
        {
            return await _context.FireTrucks
                .AnyAsync(f => f.IdFireTruck == id);
        }

        private async Task<bool> CheckFighter(int id)
        {
            return await _context.Firefighters
                .AnyAsync(f => f.IdFirefighter == id);
        }
    }
}
