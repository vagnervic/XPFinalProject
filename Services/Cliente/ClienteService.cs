using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XPFinalProject.Data;
using XPFinalProject.Dto.Cliente;
using XPFinalProject.Models;

namespace XPFinalProject.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        { 
            _context = context;
        }

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteSeek => clienteSeek.Id == idCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum rgistro encontrado!";
                    return resposta;
                }

                resposta.Dados = cliente;
                resposta.Mensagem = "Autor localizado!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                resposta.Dados = clientes;
                resposta.Mensagem = "Coleta de clientes realizada com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> CriarCliente(ClienteDto clienteDTOins)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var cliente = new ClienteModel()
                {
                    Nome = clienteDTOins.Nome,
                    SobreNome = clienteDTOins.SobreNome
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.OrderBy(c => c.Id).LastOrDefaultAsync();
                resposta.Mensagem = "cliente criado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

       }

        public async Task<ResponseModel<ClienteModel>> EditarCliente(ClienteDtoUpd clienteDTOUpd)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var clienteUpd = await _context.Clientes.FirstOrDefaultAsync(clientedb => clientedb.Id == clienteDTOUpd.Id);
                if (clienteUpd == null)
                {
                    resposta.Mensagem = "nenhum cliente localizado";
                    return resposta;
                }
                clienteUpd.Nome = clienteDTOUpd.Nome;
                clienteUpd.SobreNome = clienteDTOUpd.SobreNome;

                _context.Update(clienteUpd);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.FirstOrDefaultAsync(clientedb => clientedb.Id == clienteDTOUpd.Id);
                resposta.Mensagem = "cliente atualizado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> ExcluirCliente(int idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(clientedb => clientedb.Id == idCliente);

                if (cliente == null) 
                {
                    resposta.Mensagem = "nenhum cliente localizado";
                    return resposta;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.FirstOrDefaultAsync(clientedb => clientedb.Id == idCliente);
                if (resposta.Dados == null)
                {
                    resposta.Mensagem = "cliente removido com sucesso";
                }
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
}
