using Devboost.ChallengeDay.Domain.DTOs;
using Devboost.ChallengeDay.Domain.Interfaces.Commands;
using Devboost.ChallengeDay.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrancacaoController: ControllerBase
    {
        private readonly ITransacaoCommand _transacaoCommand;
        private readonly ITransacaoQuery _transacaoQuery;

        [HttpGet("saldo")]
        public async Task<IActionResult> Get()
        {
            var result = await _transacaoQuery.GetSaldo();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoDTO transacaoDTO)
        {
            try
            {
                if (transacaoDTO == null)
                    return NotFound();

                await _transacaoCommand.AddProducer(transacaoDTO);

                return Ok("Ação efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
