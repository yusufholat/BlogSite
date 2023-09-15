using BlogSite.Entities.Concreate;
using BlogSite.Entities.Dtos;
using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);
        Task<IDataResult<IList<Category>>> GetAll();
        Task<IDataResult<IList<Category>>> GetAllNonDeleted();
        Task<IResult> Add(CategoryAddDto category, string createdByName); //CategoryAddDto using for converting
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName); //not a real delete from db
        Task<IResult> HardDelete(int categoryId);

    }
}
