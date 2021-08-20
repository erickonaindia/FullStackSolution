using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class ParkingService : IParkingService
    {
        private readonly DataContext _context;

        public ParkingService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a parking
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<Parking> AddAsync(Parking parking)
        {
            try
            {
                _context.ParkingRepository.Add(parking);
                await _context.SaveChangesAsync();
                return parking;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Delete a Parking
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Parking> DeleteAsync(int Id)
        {
            try
            {
                var result = _context.ParkingRepository
                .Find(Id);
                if (result != null)
                {
                    _context.ParkingRepository.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all Parkings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Parking> GetAll()
        {
            try
            {
                return _context.ParkingRepository;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a parking by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Parking> GetAsync(int Id)
        {
            try
            {
                return await _context.ParkingRepository.FindAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update a parking
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        public async Task<Parking> UpdateAsync(Parking parking)
        {
            try
            {
                var result = _context.ParkingRepository.Attach(parking);
                result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return parking;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
