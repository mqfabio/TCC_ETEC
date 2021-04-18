﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TCC.Interfaces;
using TCC.Models;

namespace TCC.Data
{
    public class ParticipanteEventoRepositorio : IParticipanteEventoRepositorio
    {
        string local = "Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True";
        string somee = "workstation id=TccEtec.mssql.somee.com;packet size = 4096; user id = Giselle_SQLLogin_1; pwd=a7autn81ou;data source = TccEtec.mssql.somee.com; persist security info=False;initial catalog = TccEtec";

        public async Task<bool> Cadastrar(Participante_evento pe)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[participante_evento]
                            (idEvento, idUsuario)
                        values
                            (@IdEvento, @IdUsuario)";
                    var validacao = await BuscarPeloUsuario(pe.IdUsuario, pe.IdEvento);

                    if(validacao != null) 
                    {
                        return false;
                    }
                    else
                    {
                        var resultado = await conexao.ExecuteAsync(query, pe, commandType: CommandType.Text);
                        return resultado == 1;
                    }
                        

                   
                    
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<Participante_evento> BuscarPeloUsuario(int idUsuario, int idEvento)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"SELECT idUsuario, idEvento from participante_evento WHERE idUsuario = @idUsuario and idEvento = @idEvento";

                    var param = new { idUsuario = idUsuario, idEvento = idEvento };
                    conexao.Open();
                    var resultado = await conexao.QueryAsync<Participante_evento>(query, param);

                    return resultado.FirstOrDefault();
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public async Task<bool> Deletar(int idUsuario, int idEvento)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {

                    var param = new { idUsuario = idUsuario, idEvento = idEvento };
                    var query = @"DELETE [dbo].[Participante_evento] Where idUsuario = @idUsuario and idEvento = @idEvento";

                    var resultado = await conexao.ExecuteAsync(query, param, commandType: CommandType.Text);

                    return resultado == 1;
                }  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

  
}
