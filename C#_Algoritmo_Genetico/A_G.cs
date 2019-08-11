using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_Genetico
{
    public class A_G
    {
        Random Valores_Aleatorios = new Random();
        int Relase = 3;
        double Cruzamento = 0.50;
        int[] Registro = new int[1000]; // Populacao = 1000
        int[,] Proxima_Geracao = new int[1000, 10]; // Populacao = 1000
        int[,] Valor_Ftness = new int[1000, 2]; // Populacao = 1000
        int[,] Individuo = new int[1000, 10]; // Populacao = 1000

        // int Populacao = 1000;
        // int Geracoes = 1000;
        // int Mutacao = 10;
        //Cromossomo = 10;

        public void Avaliar()
        {
            Metodo m = new Metodo();
            int a, b, boss;
            int[] Vetor = new int[10];

            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                for (b = 0; b < 10; b++)
                {
                    Vetor[b] = Individuo[a, b];
                }

                boss = m._FIT_(Vetor);
                Valor_Ftness[a, 0] = boss;
                Valor_Ftness[a, 1] = a;
            }
        }

        public void Solucao()
        {
            this.Avaliar();
            int a, b, x, y;

            for (a = 1000 - 1; a >= 1; a--)
            { // Populacao = 1000
                for (b = 1; b < a; b++)
                {
                    if (Valor_Ftness[a, 0] < Valor_Ftness[a - 1, 0])
                    {
                        y = Valor_Ftness[a, 1];
                        x = Valor_Ftness[a, 0];
                        Valor_Ftness[a, 0] = Valor_Ftness[a - 1, 0];
                        Valor_Ftness[a, 1] = Valor_Ftness[a - 1, 1];
                        Valor_Ftness[a - 1, 1] = y;
                        Valor_Ftness[a - 1, 0] = x;
                    }
                }
            }
        }

        public int Pontos()
        {
            int a, Total = 0;

            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                Total += Valor_Ftness[a, 0];
            }
            return (Total);
        }

        public double Media()
        {
            double Media = (this.Pontos()) / 1000;
            return (Media);
        }

        public int Sorteio()
        {
            int a, index = 0;
            Random random = new Random();
            var Numero = random.NextDouble();
            ;
            for (a = 0; a < 1000 - 1; a++)
            { // Populacao = 1000
                if (Numero > Registro[a] && Numero < Registro[a + 1])
                {
                    index = a;
                }
            }
            return (index);
        }

        public void Roleta(int Total)
        {
            this.Solucao();
            int a, _P_ = 0;
            if (Total == 0)
                Total = 1;
            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                Registro[a] = _P_ + Valor_Ftness[a, 0] / Total;
                _P_ += Registro[a];
            }
        }

        public void _MT_(int index)
        {
            double numero_A;
            double numero_B;
            int y, numero_C;

            do
            {
                Random random = new Random();
                numero_A = random.NextDouble() * 10;
                numero_B = Math.Round(numero_A);
                numero_C = (int)numero_B;
            } while (numero_C > 9);

            y = Valores_Aleatorios.Next(Relase + 1);

            Proxima_Geracao[index, numero_C] = y;
        }

        public void Cruzamento_X()
        {
            int S_Score, Endereco_1, Endereco_2;
            int[] Vetor_1 = new int[10];
            int[] Vetor_2 = new int[10];
            int[] F_0 = new int[10];
            int[] F_1 = new int[10];
            int a, b, y, z;
            double x, v;
            Random t = new Random();
            Random c = new Random();
            S_Score = this.Pontos();
            this.Roleta(S_Score);

            for (a = 0; a < 1000; a += 2)
            { // Populacao = 1000
                z = c.Next(100);
                if (z <= Cruzamento)
                {
                    Endereco_1 = this.Sorteio();
                    Endereco_2 = this.Sorteio();
                    x = Valores_Aleatorios.NextDouble() * 10;
                    v = Math.Round(x);
                    y = (int)v;

                    for (b = 0; b < 10; b++)
                    {
                        Vetor_1[b] = Individuo[Endereco_1, b];
                        Vetor_2[b] = Individuo[Endereco_2, b];
                    }
                    for (b = 0; b < y; b++)
                    {
                        F_0[b] = Vetor_1[b];
                        F_1[b] = Vetor_2[b];
                    }
                    for (b = y; b < 10; b++)
                    {
                        F_0[b] = Vetor_2[b];
                        F_1[b] = Vetor_1[b];
                    }

                    for (b = 0; b < 10; b++)
                    {
                        Proxima_Geracao[a, b] = F_0[b];
                        Proxima_Geracao[a + 1, b] = F_0[b];
                    }

                    z = t.Next(100);
                    if (z <= 10)
                    { // Mutação = 10
                        this._MT_(a);
                    }
                    z = t.Next(100);
                    if (z <= 10)
                    {// Mutação = 10
                        this._MT_(a + 1);
                    }

                }
                else
                {
                    a -= 2;
                }
            }

            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                for (b = 0; b < 10; b++)
                {
                    Individuo[a, b] = Proxima_Geracao[a, b];
                }
            }
            this.Solucao();
        }

        public void constroi()
        {
            int a, b;
            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                for (b = 0; b < 10; b++)
                { // Cromossomo = 10
                    Individuo[a, b] = Valores_Aleatorios.Next(Relase + 1);
                }
            }
        }

        public void info()
        {
            this.constroi();
            int a;
            for (a = 0; a < 1000; a++)
            { // Populacao = 1000
                //Console.WriteLine(a+" - Media dos Individuos: " + this.Media());
               // Console.WriteLine(" Melhor Individuo Gerado: " + Valor_Ftness[0, 0] + "\n");
                this.Cruzamento_X();
            }
            
            Console.WriteLine(" \n\t Solucao: ");

            for (a = 0; a < 10; a++)
            {
                Console.Write(" " + Individuo[0, a]);
            }
        }


    }
}

