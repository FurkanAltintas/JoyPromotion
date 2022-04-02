using System;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IContactRepository Contacts { get; }
        IContentRepository Contents { get; }
        IContentTagRepository ContentTags { get; }
        IRoleRepository Roles { get; }
        ISocialMediaRepository SocialMedias { get; }
        ITagRepository Tags { get; }
        IUserRepository Users { get; }
        IUserSocialMediaRepository UserSocialMedias { get; }
    }
}
