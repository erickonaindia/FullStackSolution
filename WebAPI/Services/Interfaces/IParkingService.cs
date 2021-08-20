using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IParkingService
    {
        Task<Parking> GetAsync(int Id);
        IEnumerable<Parking> GetAll();
        Task<Parking> AddAsync(Parking parking);
        Task<Parking> UpdateAsync(Parking parking);
        Task<Parking> DeleteAsync(int Id);
    }
}
