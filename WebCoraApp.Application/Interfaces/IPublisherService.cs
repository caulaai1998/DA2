using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Application.ViewModels;

namespace WebCoreApp.Application.Interfaces
{
    public interface IPublisherService
    {
        PublisherViewModel Add(PublisherViewModel PubliserVm);

        void Update(PublisherViewModel PubliserVm);

        void Delete(int id);

        List<PublisherViewModel> GetAll();

        PublisherViewModel GetById(int id);

        void Save();
    }
}
