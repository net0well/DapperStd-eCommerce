using DapperStd_eCommerce.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using DapperStd_eCommerce.Data;

namespace DapperStd_eCommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private IDbConnection _connection;
        private readonly IDapperFactory _dapper;
        public UsuarioRepository(IDapperFactory dapper)
        {
            _dapper = dapper;
            //_connection = new SqlConnection("Server=localhost,1433;Database=dapperStd-Commerce;User Id=sa;Password=Str0ngP@ssword!;TrustServerCertificate=True;Encrypt=False;");
        }

        public void Delete(Guid id)
        {
            using var connection = _dapper.CreateConnection();
            connection.Execute("DELETE FROM dbo.Usuarios WHERE Id = @Id", new { Id = id });
        }

        public List<Usuario> Get()
        {
            using var connection = _dapper.CreateConnection();
            return connection.Query<Usuario>("SELECT * FROM dbo.Usuarios").ToList();
        }

        public Usuario Get(Guid id)
        {
            using var connection = _dapper.CreateConnection();
            return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM dbo.Usuarios WHERE Id = @Id", new { Id = id });
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

            using var connection = _dapper.CreateConnection();
            connection.Execute(sql, usuario);
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

            using var connection = _dapper.CreateConnection();
            connection.Execute(sql, new
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
