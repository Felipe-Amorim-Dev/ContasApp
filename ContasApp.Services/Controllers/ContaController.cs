using ContasApp.Data.Entities;
using ContasApp.Data.Repositories;
using ContasApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace ContasApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        //Método para Serviço de cadastro de conta.
        [Route("cadastrar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(ContaGetModel), 200)]
        public IActionResult CadastrarConta([FromBody] ContaPostModel model)
        {
            try
            {
                //Criando um objeto da classe conta.
                var conta = new Conta
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    DataCriacao = DateTime.Now,
                    Valor = model.Valor,
                    Tipo = model.Tipo,
                    Observacao = model.Observacao,
                    Categoria = model.Categoria
                };

                //Gravando a conta no banco de dados.
                var contaRepository = new ContaRepository();
                contaRepository.Add(conta);

                //Copiando os dados da conta para a classe Conta.
                var result = ContaToModel(conta);

                //Retornando o código 200 (OK).
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        //Método para Serviço de atualização de conta.
        [Route("atualizar-conta")]
        [HttpPut]
        [ProducesResponseType(typeof(ContaGetModel), 200)]
        public IActionResult AtualizarConta([FromBody] ContaPutModel model)
        {
            try
            {
                //Consultando a conta no banco de dados através do ID.
                var contaRepository = new ContaRepository();
                var conta = contaRepository.GetById(model.Id);

                if (conta != null)
                {
                    //atualizar os dados da conta.
                    conta.Nome = model.Nome;
                    conta.Valor = model.Valor;
                    conta.Tipo = model.Tipo;
                    conta.Observacao = model.Observacao;
                    conta.Categoria = model.Categoria;

                    //Gravando no banco de dados.
                    contaRepository.Update(conta);

                    //Copiando os dados da conta para a classe Conta.
                    var result = ContaToModel(conta);

                    //Retornando o código 200 (OK).
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Produto não encontrado." });
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        //Método para Serviço de exclusão de conta.
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ContaGetModel), 200)]
        public IActionResult RemoverConta(Guid? id)
        {
            try
            {
                //Buscando no banco através do ID.
                var contaRepository = new ContaRepository();
                var conta = contaRepository.GetById(id);

                //Verificando se a conta foi encontrada.
                if (conta != null)
                {
                    //Excluindo a conta no banco.
                    contaRepository.Delete(conta);

                    //Copiando os dados da conta para a classe Conta.
                    var result = ContaToModel(conta);

                    //Retornando o código 200 (OK)
                    return StatusCode(200, result);
                }
                else
                {
                    //Retornando o código de erro 400 (Bad Request).
                    return StatusCode(400, new { mensagem = "Conta não encontrado." });
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        //Método para Serviço de consulta de conta.
        [Route("consultar-conta")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ContaGetModel>), 200)]
        public IActionResult ConsultarConta()
        {
            try
            {
                //Criando uma lista de objetos para retornar a consulta.
                var lista = new List<ContaGetModel>();

                //Acessando o banco e consultando todas as contas.
                var contaRepository = new ContaRepository();
                foreach(var item in contaRepository.GetAll())
                {
                    //Adicionando cada conta obtida na lista.
                    lista.Add(ContaToModel(item));
                }

                if(lista.Count > 0)
                {
                    //Retornando a lista com todas as contas.
                    return StatusCode(200, lista);
                }
                else
                {
                    //Retornando o código de erro 204 (No Content).
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ContaGetModel>), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var contaRepository = new ContaRepository();
                var conta = contaRepository.GetById(id);

                if (conta != null)
                {                    
                    //Copiando os dados da conta para a classe Conta.
                    var result = ContaToModel(conta);

                    //Retornando o código 200 (OK)
                    return StatusCode(200, result);
                }
                else
                {
                    //Retornando o código de erro 400 (Bad Request).
                    return StatusCode(400, new { mensagem = "Conta não encontrado." });
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }


        //Método auxiliar para copiar os dados de um objeto da classe conta para um objeto ContaGetModel.
        private ContaGetModel ContaToModel(Conta conta)
        {
            return new ContaGetModel
            {
                Id = conta.Id,
                Nome = conta.Nome,
                DataCriacao = conta.DataCriacao,
                Valor = conta.Valor,
                Tipo = conta.Tipo,
                Observacao = conta.Observacao,
                Categoria = conta.Categoria
            };
        }
    }
}
