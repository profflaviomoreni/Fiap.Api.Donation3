﻿using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IUsuarioRepository
    {

        public IList<UsuarioModel> FindAll();

        public UsuarioModel FindById(int id);

        public Task<UsuarioModel> FindByEmailAndSenha(string email, string senha);

        public int Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);

        public void Delete(int id);


    }
}
