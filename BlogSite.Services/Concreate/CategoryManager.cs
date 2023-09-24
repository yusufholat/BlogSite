using AutoMapper;
using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Entities.Dtos;
using BlogSite.Services.Abstract;
using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;
using BlogSite.Shared.Utilities.Results.Concreate;


namespace BlogSite.Services.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c=>c.Articles);
            if (category != null)
                return new DataResult<CategoryDto>(ResultStatus.Success,data:new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                });

            return new DataResult<CategoryDto>(ResultStatus.Error,message: "boyle bir kategori bulunamadi", data: new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "boyle bir kategori bulunamadi"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: "hicbir kategori bulunamadi", data:new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "hicbir kategori bulunamadi."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c=> !c.IsDeleted, c=>c.Articles); //isdeleted == false
            if (categories.Count > -1)
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories= categories,
                    ResultStatus = ResultStatus.Success,
                });

            return new DataResult<CategoryListDto>(ResultStatus.Error, data: null, message: "hicbir kategori bulunamadi");
        }


        public async Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles); //isdeleted == false
            if (categories.Count > -1)
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,
                });

            return new DataResult<CategoryListDto>(ResultStatus.Error, data: null, message: "hicbir kategori bulunamadi");
        }


        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} adli kategori basariyla eklenmistir", new CategoryDto
            {
                Category = addedCategory,
                ResultStatus= ResultStatus.Success,
                Message = $"{categoryAddDto.Name} adli kategori basariyla eklenmistir"
            });
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} adli kategori basariyla eklenmistir", new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{updatedCategory.Name} adli kategori basariyla eklenmistir"
            });
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla guncellenmistir");
            }

            return new DataResult<IList<Category>>(ResultStatus.Error, data: null, message: "boyle bir kategori bulunamadi");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla veritabanindan silinmistir");
            }
            return new Result(ResultStatus.Error, "boyle bir kategori bulunamadi");
        }



    }
}
