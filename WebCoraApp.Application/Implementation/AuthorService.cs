using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCoreApp.Application.Interfaces;
using WebCoreApp.Application.ViewModels;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.Enums;
using WebCoreApp.Data.IRepositories;
using WebCoreApp.Infrastructure.Interfaces;
using WebCoreApp.Utilities.Dtos;

namespace WebCoreApp.Application.Implementation
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private IUnitOfWork _unitOfWork;

        public AuthorService(IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }
        public AuthorViewModel Add(AuthorViewModel authorVm)
        {
            var author = Mapper.Map<AuthorViewModel, Author>(authorVm);
            _authorRepository.Add(author);
            return authorVm;
        }

        public void Delete(int id)
        {
            _authorRepository.Remove(id);
        }

        public List<AuthorViewModel> GetAll()
        {
            return _authorRepository.FindAll().ProjectTo<AuthorViewModel>().ToList();
        }

        public AuthorViewModel GetById(int id)
        {
            return Mapper.Map<Author, AuthorViewModel>(_authorRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(AuthorViewModel authorVm)
        {
            var author = Mapper.Map<AuthorViewModel, Author>(authorVm);
            _authorRepository.Update(author);
        }

    }
}
