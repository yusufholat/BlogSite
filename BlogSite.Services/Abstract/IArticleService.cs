using BlogSite.Entities.Dtos;
using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);

        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IDataResult<ArticleListDto>> GetAllNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllNonDeletedAndActive();
        Task<IResult> Add(ArticleAddDto article, string createdByName); //CategoryAddDto using for converting
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName); //not a real delete from db
        Task<IResult> HardDelete(int articleId);
    }
}
