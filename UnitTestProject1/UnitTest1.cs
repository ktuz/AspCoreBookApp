using AspCoreBookApp;
using AspCoreBookApp.Controllers;
using AspCoreBookApp.Services.Implementation;
using AspCoreBookApp.Services.Interfaces;
using AutoMapper;

using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data;
using Domain.Data.Interfaces;
using Domain.Data.Repositories;
using Domain.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestProject1
{
    
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task AddNewAuthorTest_1()
        {
            string conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IAuthorRepository authorRepository = new AuthorRepository(conString, repositoryContextFactory);
            await authorRepository.AddAuthor(new Author { Id = 0, Name = "Author4" });
            var authorList = await authorRepository.GetAuthors(0, 10);
            var ext = authorList.Records.ToList();
        }

        /* [TestMethod]
       public async Task DeleteAuthorTest_1()
        {
            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IAuthorRepository authorRepository = new AuthorRepository(conString, repositoryContextFactory);
            await authorRepository.DeleteAuthor(6);
            //var authorList = await authorRepository.GetAuthors(0, 10);
            //var ext = authorList.Records.ToList();
        }
        */
        [TestMethod]
        public async Task GetAuthorsTest_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IAuthorRepository authorRepository = new AuthorRepository(conString, repositoryContextFactory);
            var authorList = await authorRepository.GetAuthors(0, 10);
            var ext = authorList.Records.ToList();

        }


        [TestMethod]
        public async Task GetPublisherTesT_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IPublisherRepository publisherRepository = new PublisherRepository(conString, repositoryContextFactory);
            var authorList = await publisherRepository.GetPublishers(0, 10);
            var ext = authorList.Records.ToList();
        }

        [TestMethod]
        public async Task AddNewPublisherTest_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IPublisherRepository publisherRepository = new PublisherRepository(conString, repositoryContextFactory);
            await publisherRepository.AddPublisher(new Publisher { Id = 0, Name = "Publisher4" });
            var authorList = await publisherRepository.GetPublishers(0, 10);
            var ext = authorList.Records.ToList();
        }

        [TestMethod]
        public void GetBookTesT_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IBookRepository publisherRepository = new BookRepository(conString, repositoryContextFactory);
            var result  =  publisherRepository.GetBooks(0,10, "Author.Name", "Author1").Result.Records;
            var result1 = result.ToList();
            
        }

        [TestMethod]
        public async Task AddNewBookTest_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IBookRepository bookRepository = new BookRepository(conString, repositoryContextFactory);
            await bookRepository.AddBook(new Book
            {
                Id = 0,
                Name = "Book4",
                Description = "Test",
                PublishedAt = DateTime.Now,
                Price = 1,
                Publisher = new Publisher {Id=1 }, 
            });
            var authorList = await bookRepository.GetBooks(0, 10);
            var ext = authorList.Records.ToList();
        }
        [TestMethod]
        public async Task AddNewBookToAuthorTest_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();

            IAuthorRepository authorRepository = new AuthorRepository(conString, repositoryContextFactory);
            IBookRepository bookRepository = new BookRepository(conString, repositoryContextFactory);



            var txt = await bookRepository.AddBookToAuthor(new BooksToAuthors { BookId = 5, AuthorId = 3});
            var authorList = await bookRepository.GetBooks(0, 10);
            var ext = authorList.Records.ToList();
        }

        /*[TestMethod]
        public async Task DeletePublisherTest_1()
        {
            var conString = "Server=DESKTOP-RF07Q5U;Database=AspCoreBookApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            IRepositoryContextFactory repositoryContextFactory = new RepositoryContextFactory();
            IPublisherRepository publisherRepository = new PublisherRepository(conString, repositoryContextFactory);
            await publisherRepository.DeletePublisher(1);
            var authorList = await publisherRepository.GetPublishers(0, 10);
            var ext = authorList.Records.ToList();
        }*/

    }
}
