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

namespace WebCoreApp.Application.Implementation
{
    public class PublisherService : IPublisherService
    {
        private IPublisherCompanyRepository _publisherRepository;
        private IUnitOfWork _unitOfWork;

        public PublisherService(IPublisherCompanyRepository publisherRepository,
            IUnitOfWork unitOfWork)
        {
            _publisherRepository = publisherRepository;
            _unitOfWork = unitOfWork;
        }
        public PublisherViewModel Add(PublisherViewModel publisherVm)
        {
            var publisher = Mapper.Map<PublisherViewModel, Publisher>(publisherVm);
            _publisherRepository.Add(publisher);
            return publisherVm;

        }

        public void Delete(int id)
        {
            _publisherRepository.Remove(id);
        }

        public List<PublisherViewModel> GetAll()
        {
            return _publisherRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<PublisherViewModel>().ToList();
        }

        public List<PublisherViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _publisherRepository.FindAll(x => x.PublisherName.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<PublisherViewModel>().ToList();
            else
                return _publisherRepository.FindAll().OrderBy(x => x.ParentId)
                    .ProjectTo<PublisherViewModel>()
                    .ToList();
        }

        public List<PublisherViewModel> GetAllByParentId(int parentId)
        {
            return _publisherRepository.FindAll(x => x.Status == Status.Active
            && x.ParentId == parentId)
             .ProjectTo<PublisherViewModel>()
             .ToList();
        }

        public PublisherViewModel GetById(int id)
        {
            return Mapper.Map<Publisher, PublisherViewModel>(_publisherRepository.FindById(id));
        }

        public List<PublisherViewModel> GetHomeCategories(int top)
        {
            var query = _publisherRepository
                .FindAll(x => x.HomeFlag == true, c => c.Products)
                  .OrderBy(x => x.HomeOrder)
                  .Take(top).ProjectTo<PublisherViewModel>();

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
            var source = _publisherRepository.FindById(sourceId);
            var target = _publisherRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _publisherRepository.Update(source);
            _publisherRepository.Update(target);

        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PublisherViewModel publisherVm)
        {
            var publisher = Mapper.Map<PublisherViewModel, Publisher>(publisherVm);
            _publisherRepository.Update(publisher);
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _publisherRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _publisherRepository.Update(sourceCategory);
            var sibling = _publisherRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _publisherRepository.Update(child);
            }
        }

    }
}
