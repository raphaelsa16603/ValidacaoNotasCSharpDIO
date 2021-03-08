using System;
using System.Globalization;

namespace ValidacaoNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";
            bool umErro = false;
            double X = 0;
            double Y = 0;
            double mediaSemestral = 0;
            int contatorDeErros = 0;
            bool continuaLoop = false;
            do
            {
                //System.Console.WriteLine("Informe as duas notas");

                string nota1Text = "";
                contatorDeErros = 0;
                do{
                    umErro = false;
                    try
                    {
                        nota1Text = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                            umErro = true;
                    }
                    nota1Text = TrataNumeroStringDouble(nota1Text);
                    if(!nota1Text.Trim().Equals(""))
                    {
                        try
                        {
                            X = Double.Parse(nota1Text, CultureInfo.InvariantCulture);
                            //System.Console.WriteLine($"Valor de X {X}");
                        }
                        catch (Exception)
                        {
                            //System.Console.WriteLine("Erro na 1º nota informada...");
                            //System.Console.WriteLine("nota invalida");
                            X = 0;
                            umErro = true;
                        }

                        if(!(X>=0 && X<=10))
                        {
                            //System.Console.WriteLine($"Nota {X} inválida ...");
                            System.Console.WriteLine("nota invalida");
                            umErro = true;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("nota invalida");
                        umErro = true;
                    }

                    

                    contatorDeErros++;
                    if(umErro)
                    {
                        continuaLoop = true;
                    }
                    else
                    {
                        continuaLoop = false;
                    }
                    
                    if (contatorDeErros>10)
                    {
                         continuaLoop = false;
                         X = 0;
                    }
                } while (continuaLoop);

                //System.Console.WriteLine("Segunda nota...");
                string nota2Text = "";
                contatorDeErros = 0;
                do{
                    umErro = false;
                    
                    try
                    {
                        nota2Text = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                            umErro = true;
                    }
                    nota2Text = TrataNumeroStringDouble(nota2Text);
                    if(!nota1Text.Trim().Equals(""))
                    {
                        try
                        {
                            Y = Double.Parse(nota2Text, CultureInfo.InvariantCulture);
                            //System.Console.WriteLine($"Valor de X {X}");
                        }
                        catch (Exception)
                        {
                            //System.Console.WriteLine("Erro na 1º nota informada...");
                            //System.Console.WriteLine("nota invalida");
                            Y = 0;
                            umErro = true;
                        }
                        if(!(Y>=0 && Y<=10))
                        {
                            //System.Console.WriteLine($"Nota {X} inválida ...");
                            System.Console.WriteLine("nota invalida");
                            umErro = true;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("nota invalida");
                        umErro = true;
                    }

                    contatorDeErros++;
                    if(umErro)
                    {
                        continuaLoop = true;
                    }
                    else
                    {
                        continuaLoop = false;
                    }
                    
                    if (contatorDeErros>10)
                    {
                         continuaLoop = false;
                         Y = 0;
                    }
                } while (continuaLoop);


                //System.Console.WriteLine($"Valor de X {X} e de Y {Y}");
                mediaSemestral = (X + Y) / 2;
                mediaSemestral = Math.Round(mediaSemestral,2); //-- Sua implementação excedeu o tamanho máximo de output de execução.
                //System.Console.WriteLine($"Média de  X {X} + Y {Y} / 2 = {mediaSemestral}");
                System.Console.WriteLine("media = {0:0.00}", mediaSemestral);
                
                contatorDeErros = 0;
                do
                {
                    System.Console.WriteLine("novo calculo (1-sim 2-nao)");
                    try
                    {
                        opcao = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        opcao = "3";
                    }
                    contatorDeErros ++;

                    if(( opcao != "1" && opcao != "2") )
                    {
                        continuaLoop = true;
                    }
                    else
                    {
                        continuaLoop = false;
                    }
                    
                    if (contatorDeErros>10)
                    {
                         continuaLoop = false;
                         opcao = "2";
                    }
                } while (continuaLoop);

                if(( opcao == "1") )
                {
                    continuaLoop = true;
                }
                else
                {
                    continuaLoop = false;
                }
                

            } while (continuaLoop);
        }

        private static string TrataNumeroStringDouble(string textoNumero)
        {
            int contador = 0;
            string lerNumero = textoNumero;
            foreach (char c in lerNumero)
            {
                if (c == ',' || c == '.')
                {
                    contador++;
                }
            }
            string lerNumeroTemp = "";
            if (contador > 1)
            {
                foreach (char c in lerNumero)
                {
                    if (c == ',' || c == '.')
                    {

                        if (contador <= 1)
                        {
                            lerNumeroTemp += c;
                        }
                        contador--;
                    }
                    else
                    {
                        lerNumeroTemp += c;
                    }
                }
                lerNumero = lerNumeroTemp;
            }
            return lerNumero;
        }
    }
}
