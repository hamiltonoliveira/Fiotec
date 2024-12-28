﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ISolicitante 
    {
        Task<Solicitante> GetSolicitanteAsync(string cpf, string nome);
        Task<Solicitante> InsertAsync(Solicitante solicitante);
    }
}