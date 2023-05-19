using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteGauss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Cadastro>();
            var rnd = new Random();

            for(int i = 1; i < 20; i++)
            {
                var num = rnd.Next(1, 7);
                var cad = new Cadastro
                {
                    CadastroId= i,
                    Setor = (TipoSetor)num,
                    Nome = $"Nome{i}",
                    Salario = 1800.00 * i
                };
                lista.Add(cad);
                Console.WriteLine($"ID:{i} | Setor:{cad.Setor} | Nome:{cad.Nome} | Salário:{cad.Salario.ToString("C")}");
            }

            foreach(var item in Enum.GetValues(typeof(TipoSetor))) 
            {
                var setor = (TipoSetor)item;
                Console.WriteLine("\n______________________________________________");
                Console.WriteLine($"\nQtde de funcionários do setor {item}: {lista.Where(w => w.Setor == setor).Count()}");
                Console.WriteLine($"Média de salários do setor {item}: {(lista.Where(w => w.Setor == setor).Any() ? lista.Where(w => w.Setor == setor).Average(s => s.Salario) : 0)}");
            }

            var lista2 = new List<Cadastro>();
            bool continuarLoop = true;
            do
            {
                var cadastro = new Cadastro();
                Console.WriteLine("\n______________________________________________\n\nCadastro de funcionário");
                Console.Write("\nDigite o nome do funcionário: ");
                cadastro.Nome = Console.ReadLine();

                Console.Write("\nDigite o Salário do funcionário: ");
                cadastro.Salario = Convert.ToDouble(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(TipoSetor)))
                    Console.WriteLine($"\n{i} - {Enum.GetName(typeof(TipoSetor), i)}");

                Console.Write("\nDigite a funcao (1 a 7): ");
                var recebeValor = Console.ReadLine();
                var intValor = Convert.ToInt32(recebeValor);
                var setor = (TipoSetor)intValor;

                cadastro.Setor = setor;

                Console.Write("\nDeseja continuar? (S/N) ");
                var resposta = Console.ReadLine();
                if (resposta?.ToLower() == "n" || resposta?.ToLower() == "N")
                {
                    continuarLoop = false;
                }

            } while (continuarLoop);


            Console.ReadLine();

        }
    }
}