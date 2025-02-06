using XPFinalProject.Dto.Cliente;
using XPFinalProject.Models;

namespace XPFinalProject.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente);
        Task<ResponseModel<ClienteModel>> CriarCliente(ClienteDto clienteDTO);
        Task<ResponseModel<ClienteModel>> EditarCliente(ClienteDtoUpd clienteDTOUpd);
        Task<ResponseModel<ClienteModel>> ExcluirCliente(int idCliente);




    }
}
