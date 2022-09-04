using uCarOk.Data.Entities.Base;
using uCarOk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uCarOk.Domain.DTOs;

namespace uCarOk.Repositories.Interface
{
    public interface IMechanicRepository
    {
        Task<ServiceResponse<List<GetMechanicDTO>>> GetAllMechanic();
        Task<ServiceResponse<GetMechanicDTO>> GetMechanicById(Guid id);
        Task<ServiceResponse<List<GetMechanicDTO>>> AddMechanic(AddMechanicDTO newMechanic);
        Task<ServiceResponse<GetMechanicDTO>> UpdateMechanic(UpdateMechanicDTO actPersonaje);
        Task<ServiceResponse<List<GetMechanicDTO>>> DeleteMechanic(Guid id);
    }
}
