using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial7.DTOs.Request;
using Tutorial7.DTOs.Response;
using Tutorial7.DTOs.Responses;
using Tutorial7.Models;

namespace Tutorial7.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<GetTripDto>> GetTrips();
        public Task<IActionResult> DeleteClient(int id);
        public Task<IActionResult> AssignClientToTrip(int id, AssignClientToTripDto dto);
    }
    public class DatabaseService : IDbService
    {
        private ITripDbContext _context;

        public DatabaseService(ITripDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AssignClientToTrip(int idTrip, AssignClientToTripDto dto)
        {
            int idClient;
            //check client or create
            idClient = await CheckClientPesel(dto) != 0 ? await CheckClientPesel(dto) : await CreateClient(dto);

            //check if tour exists
            if (!await CheckTourExist(idTrip)) return new BadRequestObjectResult($"Trip N{idTrip} does not exist");

            //check if client is already ssigned to tour
            if (await CheckAssignedTourForClient(idClient, idTrip)) return new BadRequestObjectResult($"There is assigned tour for client N{idClient}");

            //check if there is enough #seats
            if(!await CheckTripSeats(idTrip)) return new BadRequestObjectResult($"There are no available seats for trip N{idTrip}");
      

            var clientTrip = new ClientTrip
            {
                IdClient = idClient,
                IdTrip = idTrip,
                RegisteredAt = System.DateTime.Now,
                PaymentDate = dto.PaymentDate
            };
            await _context.ClientTrips.AddAsync(clientTrip);
            await _context.SaveChangesAsync();

            return new OkObjectResult($"Client N{idClient} was added to the trip N{idTrip}");
        }

        public async Task<IActionResult> DeleteClient(int id)
        {
            if (!await CheckIfClientExist(id)) return new BadRequestObjectResult($"Client N{id} does not exist");
            if (await CheckAssignedTours(id)) return new BadRequestObjectResult($"There are assigned tours for client N{id}");
    
            var client = new Client
            {
                IdClient = id
            };
            _context.Clients.Attach(client);
            _context.Entry(client).State = EntityState.Deleted;
            return new OkObjectResult(await _context.SaveChangesAsync() + " row(s) were deleted");
        }

        public async Task<IEnumerable<GetTripDto>> GetTrips()
        {
            return await _context.Trips
                .Include(t => t.CountryTrips)
                .Include(t => t.ClientTrips)
                .Select(t => new GetTripDto
                {
                    Name = t.Name,
                    Description = t.Description,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    MaxPeople = t.MaxPeople,
                    Countries = t.CountryTrips
                                .Select(ct => new GetTripCountryDto
                                {
                                    Name = ct.IdCountryNavigation.Name
                                }),
                    Clients = t.ClientTrips
                                .Select(ct => new GetTripClientDto
                                {
                                    FirstName = ct.IdClientNavigation.FirstName,
                                    LastName = ct.IdClientNavigation.LastName
                                })
                    
                })
                .OrderByDescending(t => t.DateFrom)
                .ToListAsync();
        }

        private async Task<bool> CheckAssignedTours(int id)
        {
            return await _context.ClientTrips
                .AnyAsync(ct => ct.IdClient == id);
        }
        private async Task<bool> CheckIfClientExist(int id)
        {
            return await _context.Clients
                .AnyAsync(c => c.IdClient == id);
        }

        private async Task<int> CheckClientPesel(AssignClientToTripDto dto)
        {
            return await _context.Clients
                .Where(c => c.Pesel == dto.Pesel)
                .Select(c => c.IdClient)
                .SingleOrDefaultAsync();
        }

        private async Task<int> CreateClient(AssignClientToTripDto dto)
        {
            var client = new Client
            {
                IdClient = await _context.Clients.MaxAsync(c => c.IdClient) + 1,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Pesel = dto.Pesel,
                Telephone = dto.Telephone
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client.IdClient;
        }

        private async Task<bool> CheckTourExist(int id)
        {
            return await _context.Trips
                .AnyAsync(t => t.IdTrip == id);
        }

        private async Task<bool> CheckAssignedTourForClient(int idClient, int idTrip)
        {
            return await _context.ClientTrips
                .AnyAsync(ct => ct.IdClient == idClient && ct.IdTrip == idTrip);
        }

        private async Task<bool> CheckTripSeats(int id)
        {
            int actualNumber = await _context.Trips
                .Where(t => t.IdTrip == id)
                .Select(t => t.ClientTrips.Count)
                .SingleOrDefaultAsync();
            int allowedNumber = await _context.Trips
                .Where(t => t.IdTrip == id)
                .Select(t => t.MaxPeople)
                .SingleOrDefaultAsync();
            return actualNumber < allowedNumber;
        }
    }
}
