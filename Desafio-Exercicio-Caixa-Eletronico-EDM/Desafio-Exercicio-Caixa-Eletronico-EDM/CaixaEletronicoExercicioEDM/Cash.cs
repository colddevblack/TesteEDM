using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronicoExercicioNotas
{
    public class Cash
    {
        public int Nota { get; set; }
        public int Valor { get; set; }
        public List<int> QuantidadeCedulas { get; set; }
        public int ValorTotal { get { return this.Nota * this.Valor; } }

        public Cash(int nota, int valor)
        {
            
            
           
            this.Nota = nota;
            this.Valor = valor;
           
        }
        public Cash() { }
        public override string ToString()
        {
            if (this.Nota == 0)
                return "Valor Saque = " + this.Valor;
            else
                return String.Format("{0:c}", this.Nota) + " = " + this.Valor + String.Format(" ==> {0:c}", this.ValorTotal);
        }
    }
}
