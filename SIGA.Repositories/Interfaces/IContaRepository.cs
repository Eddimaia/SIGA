﻿using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;
public interface IContaRepository : IRepository<Funcionario>
{
    Task<Funcionario> GetByLogin(string login);
}
