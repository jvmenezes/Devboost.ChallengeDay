using Devboost.ChallengeDay.Domain.DTOs;
using Devboost.ChallengeDay.Domain.Interfaces.Commands;
using Devboost.ChallengeDay.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Devboost.ChallengeDay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrancacaoController: ControllerBase
    {
        private readonly ITransacaoCommand _transacaoCommand;
        private readonly ITransacaoQuery _transacaoQuery;

        [HttpGet("saldo")]
        public ActionResult<float> Get()
        {
            return Ok(_transacaoQuery.GetSaldo());
        }

        [HttpPost]
        public ActionResult Post([FromBody] TransacaoDTO transacaoDTO)
        {
            try
            {
                if (transacaoDTO == null)
                    return NotFound();

                ITransacaoCommand.Add(transacaoDTO);

                return Ok("Ação efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
