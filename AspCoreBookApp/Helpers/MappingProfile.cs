using AutoMapper;
using Domain.Core.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(x => x.BooksToAuthors.Select(y => y.Author).ToList()));


            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher.PublisherID))
                .ForMember(dest => dest.BooksToAuthors, opt => opt.MapFrom(src => src.Authors))
                .AfterMap((src, dest) =>
                {
                    foreach (var b in dest.BooksToAuthors)
                    {
                        b.BookId = src.ID;
                    }
                });
            CreateMap<BookDto, BooksToAuthors>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.ID));

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(x => x.Id));
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorID))
                .ForMember(dest => dest.BooksToAuthors, opt => opt.Ignore());
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src=>src.BooksToAuthors))
            //.AfterMap((src, dest) =>
            //{
            //    foreach (var b in dest.BooksToAuthors)
            //    {
            //        b.AuthorId = src.AuthorID;
            //    }
            //});
            CreateMap<AuthorDto, BooksToAuthors>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorID));
            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.PublisherID, opt => opt.MapFrom(x => x.Id));

            CreateMap<PublisherDto, Publisher>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.PublisherID));

            CreateMap<BooksToAuthorsDto, AuthorDto>()
                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(x => x));
            /*
            CreateMap<BooksToAuthors, Author>()
                .ForMember(dest=>dest.Id, opt=>opt.MapFrom(x=>x.AuthorId));*/


        }
    }
}
