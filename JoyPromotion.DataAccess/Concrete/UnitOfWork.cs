using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.DataAccess.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private DpCategoryRepository _categoryRepository;


        public UnitOfWork(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICategoryRepository Categories => _categoryRepository ?? new DpCategoryRepository(_dbConnection);

        public IContactRepository Contacts => throw new NotImplementedException();

        public IContentRepository Contents => throw new NotImplementedException();

        public IContentTagRepository ContentTags => throw new NotImplementedException();

        public IRoleRepository Roles => throw new NotImplementedException();

        public ISocialMediaRepository SocialMedias => throw new NotImplementedException();

        public ITagRepository Tags => throw new NotImplementedException();

        public IUserRepository Users => throw new NotImplementedException();

        public IUserSocialMediaRepository UserSocialMedias => throw new NotImplementedException();

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
