﻿namespace ChurchManagement.Core.Entidades
{
    public partial class Usuario
    {
        public Usuario(string nome, string email, string senha, string papel)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Papel = papel;
        }

        public Usuario(int idUsuario, string nome, string email, string senha, string papel)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Papel = papel;
        }
        public int IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Papel { get; private set; }

        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
