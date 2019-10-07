using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCoreApp.Application.Interfaces;
using WebCoreApp.Application.ViewModels.Common;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;
using WebCoreApp.Infrastructure.Interfaces;
using WebCoreApp.Utilities.Dtos;

namespace WebCoreApp.Application.Implementation
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository,
           IUnitOfWork unitOfWork)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ContactViewModel pageVm)
        {
            var page = Mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Add(page);
        }

        public void Delete(string id)
        {
            _contactRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ContactViewModel> GetAll()
        {
            return _contactRepository.FindAll().ProjectTo<ContactViewModel>().ToList();
        }

        public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _contactRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<ContactViewModel>()
            {
                Results = data.ProjectTo<ContactViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }


        public ContactViewModel GetById(string id)
        {
            return Mapper.Map<Contact, ContactViewModel>(_contactRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ContactViewModel pageVm)
        {
            var page = Mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Update(page);
        }
    }
}
