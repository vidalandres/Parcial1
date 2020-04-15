using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class LiquidacionService
    {
        private readonly ConnectionManager _conexion;
        private readonly LiquidacionRepository _repositorio;

        public LiquidacionService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new LiquidacionRepository(_conexion);
        }

        public GuardarResponse Guardar(Liquidacion liq)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(liq);
                _conexion.Close();
                return new GuardarResponse(liq);
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Liquidacion> ConsultarTodos()
        {
            _conexion.Open();
            List<Liquidacion> liqs = _repositorio.ConsultarTodos();
            _conexion.Close();
            return liqs;
        }

    }

    public class GuardarResponse
    {
        public GuardarResponse(Liquidacion liq)
        {
            Error = false;
            Liquidacion = liq;
        }
        public GuardarResponse(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Liquidacion Liquidacion { get; set; }
    }

    
}
