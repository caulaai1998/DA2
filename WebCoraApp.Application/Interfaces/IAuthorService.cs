using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Application.ViewModels;
using WebCoreApp.Utilities.Dtos;

namespace WebCoreApp.Application.Interfaces
{
    public interface IAuthorService
    {
        AuthorViewModel Add(AuthorViewModel productCategoryVm);

        void Update(AuthorViewModel productCategoryVm);

        void Delete(int id);

        List<AuthorViewModel> GetAll();

        List<AuthorViewModel> GetAll(string keyword);

        List<AuthorViewModel> GetAllByParentId(int parentId);

        AuthorViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        List<AuthorViewModel> GetHomeCategories(int top);




        void Save();
    }
}
