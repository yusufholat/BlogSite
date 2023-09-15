using BlogSite.Data.Abstact;
using BlogSite.Entities.Concreate;
using BlogSite.Entities.Dtos;
using BlogSite.Services.Abstract;
using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;
using BlogSite.Shared.Utilities.Results.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Services.Concreate
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if(article != null) { 
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, data: null, message: "boyle bir makale bulunamadi");
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, data: null, message: "makaleler bulunamadi");
        }
        public async Task<IDataResult<ArticleListDto>> GetAllNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, data: null, message: "makaleler bulunamadi");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, data: null, message: "makaleler bulunamadi");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsnyc(a => a.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive && a.CategoryId == categoryId, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success,
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, data: null, message: "makaleler bulunamadi");
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, data: null, message: "boyle bir kategori bulunamadi");
        }


        public Task<IResult> Add(ArticleAddDto article, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }


        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
