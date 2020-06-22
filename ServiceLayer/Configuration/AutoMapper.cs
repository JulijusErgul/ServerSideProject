using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServiceLayer.Models;
using Repository.Support;


namespace ServiceLayer.Configuration
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ToAuthorProfile());
                cfg.AddProfile(new FromAuthorProfile());
                cfg.AddProfile(new ToBookProfile());
                cfg.AddProfile(new FromBookProfile());
                cfg.AddProfile(new ToAdminProfile());
                cfg.AddProfile(new FromAdminProfile());
                cfg.ValidateInlineMaps = false;
            });
        }

        public class ToAuthorProfile : Profile
        {
            public ToAuthorProfile()
            {
                CreateMap<Author, EAuthor>();
            }
        }
        public class FromAuthorProfile : Profile
        {
            public FromAuthorProfile()
            {
                CreateMap<EAuthor, Author>();
               
            }
        }
        public class ToBookProfile : Profile
        {
            public ToBookProfile()
            {
                CreateMap<Book, EBook>();
            }
        }
        public class FromBookProfile: Profile
        {
            public FromBookProfile()
            {
                CreateMap<EBook, Book>();
            }
        }

        public class ToAdminProfile: Profile
        {
            public ToAdminProfile()
            {
                CreateMap<User, EUser>();
            }
        }

        public class FromAdminProfile: Profile
        {
            public FromAdminProfile()
            {
                CreateMap<EUser, User>();
            }
        }

    }
}