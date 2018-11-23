﻿using Biob.Data.Models;
using Biob.Services.Data.Helpers;
using System;
using System.Threading.Tasks;

namespace Biob.Services.Data.Repositories
{
    public interface ITicketRepository : IRepository
    {
        Task<Ticket> GetTicketAsync(Guid id);
        void AddTicket(Ticket ticketToAdd);
        void UpdateTicket(Ticket ticketToUpdate);
        void DeleteTicket(Ticket ticketToDelete);
        Task<PagedList<Ticket>> GetTicketsByCustomerIdAsync(Guid customerId, string orderBy, string searchQuery, int pageNumber, int pageSize);
    }
}