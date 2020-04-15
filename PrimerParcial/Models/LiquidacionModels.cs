using Entity;

namespace PrimerParcial.Models
{
    public class LiquidacionInputModel
    {
        public string NContrato { get; set; }
        public string Objeto { get; set; }
        public double ValorContrato { get; set; }
        public bool Apoyo { get; set; }
        public double ValorEstampilla { get; set; }
    }


    public class LiquidacionViewModel : LiquidacionInputModel
    {
        public LiquidacionViewModel()
        {  
        }
        public LiquidacionViewModel(Liquidacion liq)
        {
            NContrato = liq.NContrato;
            Objeto = liq.Objeto;
            ValorContrato = liq.ValorContrato;
            Apoyo = liq.Apoyo;
            ValorEstampilla = liq.ValorEstampilla;
        }
        public double ValorTotalAPagar { get; set; }
    }

}