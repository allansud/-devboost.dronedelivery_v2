﻿using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoHandler _pedidoService;

        public PedidoController(IPedidoHandler pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("realizarpedido")]
        public async Task<ActionResult> RealizarPedido([FromBody] RealizarPedidoRequest pedido)
        {
            string username = User.Identity.Name;
            var result = await _pedidoService.RealizarPedido(pedido, username);
            return Ok(result);
        }

        [HttpPost("distribuirpedido")]
        public async Task<ActionResult> DistribuirPedido()
        {
            await _pedidoService.DistribuirPedido();
            return Ok();
        }
    }
}
