using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace CaixaEletronicoExercicioNotas
{
    public class CaixaEletronico
    {
        private readonly List<int> NotasDisponiveis = new List<int>() { 10, 20, 50, 100 };
        private readonly List<int> NotasDisponiveisQuantidade = new List<int>() { 10, 10, 10, 10 };

        List<int> cedula10 = new List<int> { 10, 10, 10, 10, 10 };
        List<int> cedula20 = new List<int> { 20, 20, 20, 20, 20 };
        List<int> cedula50 = new List<int> { 50, 50, 50, 50, 50 };
        List<int> cedula100 = new List<int> { 100, 100, 100, 100, 100 };


        public List<Cash> SepararNotas(int valor)
        {
            this.Validar(valor);

            return this.Separar(valor);
        }

        private void Validar(int valor)
        {
            if (this.NotasDisponiveis == null || this.NotasDisponiveis.Count() == 0 || this.cedula10.Count() == 0 || this.cedula100.Count() <= 0)
                throw new Exception("Nenhuma nota disponível para realizar o Saque");

            if (this.NotasDisponiveis.FirstOrDefault(x => x == 1) == 1)
                throw new Exception("Na lista de Notas disponíveis não pode ser adicionado a nota R$ 1,00");

            if (valor <= 9)
                throw new Exception("Valor não pode ser menor ou igual a R$ 9,00 Reais");

            if (valor >= 32767)
                throw new Exception("Valor não pode ser maior ou igual a R$ 32.767,00 Reais");
        }

        private List<Cash> Separar(int valor)
        {

            var notas = new List<Cash>
            {
                new Cash(0, valor)

            };



            foreach (var nota in this.NotasDisponiveis.OrderByDescending(x => x))
            {
                valor = this.Add(notas, valor, nota);
                cedula100.Remove(valor);



            }
           
            if (valor > 0)
                throw new Exception("Valor Inválido, Notas Disponíveis " + this.StrNotasDisponiveis());

            return notas;
        }

        private int Add(List<Cash> notas, int valor, int nota)
        {
            int valorAdd = 0;

            if (valor >= nota)
            {
                int divRem = valor / nota;
                valor %= nota;
                if (valor == 10)
                {
                    valor += nota;
                    if (divRem > 1)
                    {
                        valorAdd = divRem - 1;

                    }

                }
                else
                {
                    valorAdd = divRem;
                }
            }

            notas.Add(new Cash(nota, valorAdd));

            //if (nota == 10)
            //{
            //    cedula10.Remove(nota);
                
            //};

            
            //if (nota == 100)
            //{
            //    cedula100.Remove(nota);
            //};


            return valor;
        }

        public void Exibir(List<Cash> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString() + " ");

            }

            Console.WriteLine("");
            Console.WriteLine("Total = " + String.Format("{0:c}", lista.Where(x => x.Nota != 0).Sum(p => p.ValorTotal)));
            Console.WriteLine("Quantidade de Notas = " + lista.Where(x => x.Nota != 0).Sum(p => p.Valor));
            Console.WriteLine("");
            Console.WriteLine("Loading..... Reabastecendo cédulas");
            Console.WriteLine("");
            Console.WriteLine(""); 
      

        }

        private string StrNotasDisponiveis()
        {
            string textoNotas = "";
            foreach (var item in this.NotasDisponiveis)
            {
                textoNotas += string.Format("{0:c}", item) + ", ";
            }
            return textoNotas;
        }
        public void ContagemCedulas(List<Cash> lista)
        {
            
            if (lista[1].Valor != 0)
            {
                for (int i = 0; i < lista[1].Valor; i++)
                {
                    
                    cedula100.Remove(lista[1].Nota);
                }

            }

            if (lista[2].Valor != 0)
            {
                for (int i = 0; i < lista[2].Valor; i++)
                {
                   
                    cedula50.Remove(lista[2].Nota);
                }

            }
            if (lista[3].Valor != 0)
            {
                for (int i = 0; i < lista[3].Valor; i++)
                {
                    
                    cedula20.Remove(lista[3].Nota);
                }

            }

            if (lista[4].Valor != 0)
            {
                for (int i = 0; i < lista[4].Valor; i++)
                {
                    
                    cedula10.Remove(lista[4].Nota);
                }

            }

            var cedulas = lista.Where(x => x.Nota != 0).Sum(p => p.Valor);
            
            if (cedula100.Count() == 0 || cedula50.Count() == 0 || cedula20.Count() == 0 || cedula10.Count() == 0)
            {
                throw new Exception("SAQUE NÃO FOI EFETUADO, CEDULAS INSUFICIENTES PARA ESTE SAQUE! ");
            }
        }

    }
}
