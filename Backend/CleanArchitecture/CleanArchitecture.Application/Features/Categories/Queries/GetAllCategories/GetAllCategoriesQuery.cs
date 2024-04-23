using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        private readonly ICategoryRepositoryAsync _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(
            ICategoryRepositoryAsync categoryRepository, 
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCategoriesParameter>(request);
            var result = await _categoryRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var viewModels = _mapper.Map<IEnumerable<GetAllCategoriesViewModel>>(result);
            return new PagedResponse<IEnumerable<GetAllCategoriesViewModel>> (viewModels, validFilter.PageNumber, validFilter.PageSize); ;
        }
    }
}
