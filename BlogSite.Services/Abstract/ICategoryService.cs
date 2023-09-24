using BlogSite.Entities.Dtos;
using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);

        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto category, string createdByName); //CategoryAddDto using for converting
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName); //not a real delete from db
        Task<IResult> HardDelete(int categoryId);

    }
}
