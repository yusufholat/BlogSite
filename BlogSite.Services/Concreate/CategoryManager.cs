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

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c=>c.Articles);
            if (category != null)
                return new DataResult<Category>(ResultStatus.Success,data:category);

            return new DataResult<Category>(ResultStatus.Error, data:null, message: "boyle bir kategori bulunamadi");
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
                return new DataResult<IList<Category>>(ResultStatus.Success,data:categories);

            return new DataResult<IList<Category>>(ResultStatus.Error, data: null, message: "hicbir kategori bulunamadi");
        }

        public async Task<IDataResult<IList<Category>>> GetAllNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c=> !c.IsDeleted, c=>c.Articles); //isdeleted == false
            if (categories.Count > -1)
                return new DataResult<IList<Category>>(ResultStatus.Success, data: categories);

            return new DataResult<IList<Category>>(ResultStatus.Error, data: null, message: "hicbir kategori bulunamadi");
        }


        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
            }).ContinueWith(t => _unitOfWork.SaveAsync()); //creating new task, faster

            //await _unitOfWork.SaveAsync(); //this little bit slower

            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adli kategori basariyla eklenmistir");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if(category != null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note = categoryUpdateDto.Note;
                category.IsActive = categoryUpdateDto.IsActive;
                category.IsDeleted = categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());

                return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} adli kategori basariyla guncellenmistir");
            }

            return new DataResult<IList<Category>>(ResultStatus.Error, data: null, message: "boyle bir kategori bulunamadi");
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());

                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla guncellenmistir");
            }

            return new DataResult<IList<Category>>(ResultStatus.Error, data: null, message: "boyle bir kategori bulunamadi");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla veritabanindan silinmistir");
            }
            return new Result(ResultStatus.Error, "boyle bir kategori bulunamadi");
        }

    }
}
