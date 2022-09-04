using uCarOk.Data.DataContext;
using uCarOk.Data.Entities.Base;
using uCarOk.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uCarOk.Data.Entities;
using uCarOk.Domain.DTOs;
using AutoMapper;

namespace uCarOk.Data.Repositories.Concrete
{
    public class MechanicRepository: IMechanicRepository
    {
        public IMapper _mapper { get; }
        private readonly BaseDataContext _context;
        public MechanicRepository(IMapper mapper, BaseDataContext dataContext)
        {
            _context = dataContext;
            _mapper = mapper;
            
        }

        public async Task<ServiceResponse<List<GetMechanicDTO>>> GetAllMechanic()
        {
            var serviceResponse = new ServiceResponse<List<GetMechanicDTO>>();
            serviceResponse.Data = await _context.Mechanics.Select(c => _mapper.Map<GetMechanicDTO>(c)).ToListAsync();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMechanicDTO>> GetMechanicById(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetMechanicDTO>();
            var mechanic = await _context.Mechanics.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetMechanicDTO>(mechanic);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMechanicDTO>>> AddMechanic(AddMechanicDTO newMechanic)
        {
            var serviceResponse = new ServiceResponse<List<GetMechanicDTO>>();
            Mechanic mechanic = _mapper.Map<Mechanic>(newMechanic);
            _context.Mechanics.Add(mechanic);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Mechanics.Select(c => _mapper.Map<GetMechanicDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMechanicDTO>> UpdateMechanic(UpdateMechanicDTO updatedMechanic)
        {
            ServiceResponse<GetMechanicDTO> response = new ServiceResponse<GetMechanicDTO>();
            try{
                var mechanic = await _context.Mechanics.FirstOrDefaultAsync(c => c.Id == updatedMechanic.Id);

                mechanic.Name = updatedMechanic.Name;
                mechanic.LastName = updatedMechanic.LastName;
                mechanic.PhoneNumber = updatedMechanic.PhoneNumber;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetMechanicDTO>(mechanic);
            }catch(Exception ex){

                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetMechanicDTO>>> DeleteMechanic(Guid id)
        {
            ServiceResponse<List<GetMechanicDTO>> response = new ServiceResponse<List<GetMechanicDTO>>();
            try{
                var mechanic = await _context.Mechanics.FirstAsync(c => c.Id == id);
                _context.Mechanics.Remove(mechanic);
                await _context.SaveChangesAsync();
                response.Data = _context.Mechanics.Select(c => _mapper.Map<GetMechanicDTO>(c)).ToList();
            }catch(Exception ex){

                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}