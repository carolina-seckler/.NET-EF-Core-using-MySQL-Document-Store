using Library.Application.Commands.Model;
using Library.Application.Interfaces.Command;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Mapper
{
    public class PublisherCommandMapper : IPublisherCommandMapper
    {
        public PublisherCommandModel GetPublisherByIdMapper(Publisher publisher) 
        {
            PublisherCommandModel model = new PublisherCommandModel();
            model.Name = publisher.Name;
            model.Address = publisher.Address;
            return model;
        }
    }
}
