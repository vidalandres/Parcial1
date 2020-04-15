using System;

namespace Entity
{
    public class Liquidacion
    {
        public string NContrato { get; set; }
        public string Objeto { get; set; }
        public double ValorContrato { get; set; }
        public bool Apoyo { get; set; }
        public double ValorEstampilla { get{ return Apoyo?ValorContrato*0.1:ValorContrato*0.2; } set{} }
        public double n { get; set; }
        public double i { get; set; }

        public Liquidacion() {
            this.ValorContrato = 0;
            this.Apoyo = true;
        }

    }
}
