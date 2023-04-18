using Model;

namespace Exec
{
    public class Execute : IExecute
    {
        private readonly ICalc calcValues;

        public Execute(ICalc calcValues)
        {
            this.calcValues = calcValues;
        }
        private int MenuSelection()
        {
            Console.WriteLine("\n[1] Subtração");
            Console.WriteLine("[2] Divisão");
            Console.WriteLine("[3] Adição");
            Console.WriteLine("[4] Multiplicação ");
            Console.WriteLine("\n[5] Finalizar\n");
            var type = Console.ReadLine();

            if (type?.Length == 0) return 6;

            return Convert.ToInt32(type);
        }
        private string CheckValue()
        {
            decimal CheckType(string text)
            {
                bool stats = true;
                var value = "";
                while (stats)
                {
                    Console.WriteLine(text);
                    value = Console.ReadLine();
                    if (value?.Length == 0)
                    {
                        Console.WriteLine("\n[!] Nenhum valor foi informado!\n ");
                    }
                    else stats = false;
                }

                return Convert.ToDecimal(value);
            }

            decimal value1 = CheckType("\n[!] Informe o primeiro valor ( x | z ):\n ");
            decimal value2 = CheckType($"\n[!] Informe o segundo valor ( {value1} | z ):\n ");

            return $"{value1}_{value2}";
        }
        public void Start()
        {
            bool status = true;
            while (status)
            {
                int type = MenuSelection();

                switch (type)
                {
                    case 1:
                        string[] value = Convert.ToString(CheckValue()).Split("_");
                        decimal result = calcValues.Subtraction(
                            Convert.ToDecimal(value[0]),
                            Convert.ToDecimal(value[1])
                        );
                        Console.Clear();
                        Console.WriteLine($"\n[#] Resultado final ( {value[0]} - {value[1]} ): {result}\n ");
                        break;
                    case 2:
                        value = Convert.ToString(CheckValue()).Split("_");
                        result = calcValues.Division(
                           Convert.ToDecimal(value[0]),
                           Convert.ToDecimal(value[1])
                        );
                        Console.Clear();
                        Console.WriteLine($"\n[#] Resultado final ( {value[0]} / {value[1]} ): {result}\n ");
                        break;
                    case 3:
                        value = Convert.ToString(CheckValue()).Split("_");
                        result = calcValues.Add(
                           Convert.ToDecimal(value[0]),
                           Convert.ToDecimal(value[1])
                        );
                        Console.Clear();
                        Console.WriteLine($"\n[#] Resultado final ( {value[0]} + {value[1]} ): {result}\n ");
                        break;
                    case 4:
                        value = Convert.ToString(CheckValue()).Split("_");
                        result = calcValues.Multiplication(
                             Convert.ToDecimal(value[0]),
                             Convert.ToDecimal(value[1])
                         );
                        Console.Clear();
                        Console.WriteLine($"\n[#] Resultado final ( {value[0]} x {value[1]} ): {result}\n ");
                        break;
                    case 5:
                        status = false;
                        Console.Clear();
                        Console.WriteLine("\n[!] Calculadora finalizada com sucesso!\n");
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("\n[!] Opção invalida!\n ");
                        break;
                }
                System.Threading.Thread.Sleep(1500);
            }
        }
    }
}
