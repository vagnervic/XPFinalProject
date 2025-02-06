using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XPFinalProject.Data;
using XPFinalProject.Dto.Cliente;
using XPFinalProject.Models;
using XPFinalProject.Services.Cliente;

namespace XPFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        { 
            _clienteInterface = clienteInterface;   
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes() 
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("ContarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ContarClientes()
        {
            int totalclientes = 0;
            var clientes = await _clienteInterface.ListarClientes();
            if (clientes.Dados == null)
            {
                return Ok(totalclientes);
            }
            else return Ok(clientes.Dados.Count());
            
        }

        [HttpGet("BuscarClientePorID/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorId(int idCliente)
        {
            var clientes = await _clienteInterface.BuscarClientePorId(idCliente);
            return Ok(clientes);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarCliente(ClienteDto clientedto)
        {
            var cliente = await _clienteInterface.CriarCliente(clientedto);
            return Ok(cliente);
        }

        [HttpPost("EditarCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteDtoUpd clientedtoup)
        {
            var cliente = await _clienteInterface.EditarCliente(clientedtoup);
            return Ok(cliente);
        }

        [HttpPost("ExcluirCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> ExcluirCliente(int idClienteDeletar)
        {
            var cliente = await _clienteInterface.ExcluirCliente(idClienteDeletar);
            return Ok(cliente);
        }

        //[HttpGet("BuscarClientePorNome/{nomecliente}")]
        //public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorId(int idCliente)
        //{
        //    var clientes = await _clienteInterface.BuscarClientePorId(idCliente);
        //    return Ok(clientes);
        //}

        //CRUD

        //Contagem

        //

    }
}
