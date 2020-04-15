using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrimerParcial.Models;


namespace PrimerParcial.Controllers
{
    [Route("api/liquidacion")]
    [ApiController]
    public class LiquidacionController: ControllerBase
    {
        private readonly LiquidacionService _liqService;
        public IConfiguration Configuration { get; }
        public LiquidacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _liqService = new LiquidacionService(connectionString);
        }
        // GET: api/Liquidacion
        [HttpGet]
        public IEnumerable<LiquidacionViewModel> Gets()
        {
            var liqs = _liqService.ConsultarTodos().Select(p=> new LiquidacionViewModel(p));
            return liqs;
        }

        // POST: api/Liquidacion
        [HttpPost]
        public ActionResult<LiquidacionViewModel> Post(LiquidacionInputModel liqInput)
        {
            Liquidacion liq = MapearLiquidacion(liqInput);
            var response = _liqService.Guardar(liq);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Liquidacion);
        }

        private Liquidacion MapearLiquidacion(LiquidacionInputModel liqInput)
        {
            var liq = new Liquidacion
            {
                NContrato = liqInput.NContrato,
                Objeto = liqInput.Objeto,
                ValorContrato = liqInput.ValorContrato,
                Apoyo = liqInput.Apoyo,
                ValorEstampilla = liqInput.ValorEstampilla
            };
            return liq;
        }
    }

}