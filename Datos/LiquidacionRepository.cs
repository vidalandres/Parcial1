using System.Collections.Generic;  
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class LiquidacionRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Liquidacion> _liqs = new List<Liquidacion>();

        public LiquidacionRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Liquidacion liq)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into [liqs].[dbo].[liq] (NContrato,Objeto,ValorContrato,Apoyo,ValorEstampilla)
                                                    values (@NContrato,@Objeto,@ValorContrato,@Apoyo,@ValorEstampilla)";
                command.Parameters.AddWithValue("@NContrato", liq.NContrato);
                command.Parameters.AddWithValue("@Objeto", liq.Objeto);
                command.Parameters.AddWithValue("@ValorContrato", liq.ValorContrato);
                command.Parameters.AddWithValue("@Apoyo", liq.Apoyo);
                command.Parameters.AddWithValue("@ValorEstampilla", liq.ValorEstampilla);
                var filas = command.ExecuteNonQuery();
            }

        }

        public List<Liquidacion> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Liquidacion> liqs = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from [liqs].[dbo].[liq]";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liq = DataReaderMapToPerson(dataReader);
                        liqs.Add(liq);
                    }
                }
            }
            return liqs;
        }

        private Liquidacion DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
                Liquidacion liq = new Liquidacion();
                liq.NContrato = (string)dataReader["NContrato"];
                liq.Objeto = (string)dataReader["Objeto"];
                liq.ValorContrato = (double)dataReader["ValorContrato"];
                liq.Apoyo = (bool)dataReader["Apoyo"];
                liq.ValorEstampilla = (double)dataReader["ValorEstampilla"];
                return liq;
        }
    }
}




