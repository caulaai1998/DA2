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
            return _authorRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<AuthorViewModel>().ToList();
        }

        public List<AuthorViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _authorRepository.FindAll(x => x.AuthorName.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<AuthorViewModel>().ToList();
            else
                return _authorRepository.FindAll().OrderBy(x => x.ParentId)
                    .ProjectTo<AuthorViewModel>()
                    .ToList();
        }

        public List<AuthorViewModel> GetAllByParentId(int parentId)
        {
            return _authorRepository.FindAll(x => x.Status == Status.Active
            && x.ParentId == parentId)
             .ProjectTo<AuthorViewModel>()
             .ToList();
        }

        public AuthorViewModel GetById(int id)
        {
            return Mapper.Map<Author, AuthorViewModel>(_authorRepository.FindById(id));
        }

        public List<AuthorViewModel> GetHomeCategories(int top)
        {
            var query = _authorRepository
                .FindAll(x => x.HomeFlag == true, c => c.Products)
                  .OrderBy(x => x.HomeOrder)
                  .Take(top).ProjectTo<AuthorViewModel>();

            var categories = query.ToList();
            foreach (var category in categories)
            {
                //category.Products = _productRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _authorRepository.FindById(sourceId);
            var target = _authorRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _authorRepository.Update(source);
            _authorRepository.Update(target);

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

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _authorRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _authorRepository.Update(sourceCategory);
            var sibling = _authorRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _authorRepository.Update(child);
            }
        }

    }
}
