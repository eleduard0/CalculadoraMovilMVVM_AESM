using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraMovilMVVM_AESM.Model
{
    public class CalculadoraModel
    {
        public double PrimerNumero { get; set; }
        public double SegundoNumero { get; set; }
        public string Operacion { get; set; }

        public double RealizarCalculo()
        {
            switch (Operacion)
            {
                case "+":
                    return PrimerNumero + SegundoNumero;
                case "-":
                    return PrimerNumero - SegundoNumero;
                case "*":
                    return PrimerNumero * SegundoNumero;
                case "/":
                    if (SegundoNumero != 0)
                        return PrimerNumero / SegundoNumero;
                    else
                        throw new DivideByZeroException("Error: División por cero");
                default:
                    return 0;
            }
        }
    }
}
