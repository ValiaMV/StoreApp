using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Managers
{
    public class CategoryManager
    {
        private StoreApplicationContext _context;

        private IMapper _mapper;

        public CategoryManager(StoreApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(StoreApplicationContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(_context.Categories);
        }

    }
}
