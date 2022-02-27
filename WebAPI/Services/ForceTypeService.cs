using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Communication;

namespace WebAPI.Services
{
    public class ForceTypeService : IForceTypeService
    {
        private readonly IForceTypeRepository _forceTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ForceTypeService(IForceTypeRepository forceTypeRepository, IUnitOfWork unitOfWork)
        {
            _forceTypeRepository = forceTypeRepository;
            // voidaan merkitä kahdella tapaa: this.forceTypeService = _forceTypeService
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ForceType>> ListAsync()
        {
            return await _forceTypeRepository.ListAsync();
        }

        public async Task<SaveForceTypeResponse> SaveAsync(ForceType forceType)
        {
            try
            {
                await _forceTypeRepository.AddAsync(forceType);
                await _unitOfWork.CompleteAsync();

                return new SaveForceTypeResponse(forceType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveForceTypeResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveForceTypeResponse> UpdateAsync(int id, ForceType forceType)
        {
            var existingCategory = await _forceTypeRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new SaveForceTypeResponse("Category not found.");

            existingCategory.Type = forceType.Type;

            try
            {
                _forceTypeRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveForceTypeResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveForceTypeResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<SaveForceTypeResponse> DeleteAsync(int id)
        {
            var existingCategory = await _forceTypeRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new SaveForceTypeResponse("Category not found.");

            try
            {
                _forceTypeRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveForceTypeResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveForceTypeResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
