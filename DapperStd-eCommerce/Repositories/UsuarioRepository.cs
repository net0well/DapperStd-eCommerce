using DapperStd_eCommerce.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace DapperStd_eCommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dapperStd-Commerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public void Delete(Guid id)
        {
            _connection.Execute("DELETE FROM dbo.Usuarios WHERE Id = @Id", new { Id = id });
        }

        public List<Usuario> Get()
        {
            return _connection.Query<Usuario>("SELECT * FROM dbo.Usuarios").ToList();
        }

        public Usuario Get(Guid id)
        {
            return _connection.QueryFirstOrDefault<Usuario>("SELECT * FROM dbo.Usuarios WHERE Id = @Id", new { Id = id });
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

             _connection.Execute(sql, usuario);
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

            _connection.Execute(sql, new
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                RG = usuario.RG,
                CPF = usuario.CPF,
                NomeMae = usuario.NomeMae,
                Id = usuario.Id
            });
        }
    }
}
