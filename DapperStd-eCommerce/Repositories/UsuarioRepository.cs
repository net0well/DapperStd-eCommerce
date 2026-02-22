using DapperStd_eCommerce.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using DapperStd_eCommerce.Data;

namespace DapperStd_eCommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DbSession _session;
        public UsuarioRepository(DbSession session)
        {
            _session = session;
            //_connection = new SqlConnection("Server=localhost,1433;Database=dapperStd-Commerce;User Id=sa;Password=Str0ngP@ssword!;TrustServerCertificate=True;Encrypt=False;");
        }

        public void Delete(Guid id)
        {
            _session.Connection.Execute("DELETE FROM dbo.Usuarios WHERE Id = @Id", new { Id = id }, _session.Transaction);
        }

        public List<Usuario> Get()
        {
            return _session.Connection.Query<Usuario, Contato, Usuario>(
                @"SELECT * 
                  FROM Usuarios 
                  LEFT JOIN Contatos ON Contatos.UsuarioId = Usuarios.Id",
                (usuario, contato) =>
                {
                    usuario.Contato = contato;
                    return usuario;
                },
                _session.Transaction).ToList();
        }

        public Usuario? Get(Guid id)
        {
            return _session.Connection.Query<Usuario, Contato, Usuario>(
                @"SELECT * 
                  FROM Usuarios 
                  LEFT JOIN Contatos ON Contatos.UsuarioId = Usuarios.Id
                  WHERE Usuarios.Id = @Id", 
                (usuario, contato) =>
                {
                    usuario.Contato = contato;
                    return usuario;
                },
                new { Id = id }, _session.Transaction).FirstOrDefault();

        }

        public void Insert(Usuario usuario)
        {
            var sql = @"
                    INSERT INTO dbo.Usuarios
                    (
                        Nome,
                        Email,
                        Sexo,
                        RG,
                        CPF,
                        NomeMae,
                        SituacaoCadastro
                    )
                    VALUES
                    (
                        @Nome,
                        @Email,
                        @Sexo,
                        @RG,
                        @CPF,
                        @NomeMae,
                        @SituacaoCadastro
                    )";

            _session.Connection.Execute(sql, usuario, _session.Transaction);
        }

        public void Update(Usuario usuario)
        {
            var sql = @"
            UPDATE dbo.Usuarios
            SET Nome = @Nome,
                Email = @Email,
                RG = @RG,
                CPF = @CPF,
                NomeMae = @NomeMae
            WHERE Id = @Id                                            
            ";

            _session.Connection.Execute(sql, new
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                RG = usuario.RG,
                CPF = usuario.CPF,
                NomeMae = usuario.NomeMae,
                Id = usuario.Id
            }, _session.Transaction);
        }
    }
}
