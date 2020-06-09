using Library.Application.Commands.Model;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces.Command
{
    public interface IPublisherCommandMapper
    {
        PublisherCommandModel GetPublisherByIdMapper(Publisher publisher);
    }
}
