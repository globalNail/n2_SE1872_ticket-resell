using Repository.Interfaces;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryServices: ICategoryServices
    {
        private readonly ICategoryyRepository _repository;

        public CategoryServices(ICategoryyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return await _repository.GetCategoryById(id);
        }
    }
}
