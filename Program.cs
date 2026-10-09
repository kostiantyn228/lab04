using System;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Розрахунок податку з місячного доходу ===");
            Console.Write("Місячний дохід, грн: ");
           string input = Console.ReadLine();

            // Гілка 1
            if (!double.TryParse(input, out double income) || income <= 0)
            {
                Console.WriteLine("Помилка: дохід має бути додатним числом.");
            }
            else
            {
                const double Threshold = 6700.0;   
                const double BaseRate = 0.18;      
                const double ExtraRate = 0.05;     
                const double MilitaryRate = 0.015; 

                double excess;     
                double extraTax;  
                double baseTax = income * BaseRate;

                if (income <= Threshold)
                {
                    // Гілка 2
                    excess = 0;
                    extraTax = 0;
                }
                else
                {
                    // Гілка 3
                    excess = income - Threshold;
                    extraTax = excess * ExtraRate;
                }

                // Військовий збір нараховується завжди
                double militaryTax = income * MilitaryRate;
                double netIncome = income - baseTax - extraTax - militaryTax;

                Console.WriteLine();
                Console.WriteLine($"Дохід: {income:F2} грн");
                Console.WriteLine($"Податок 18 %: {baseTax:F2} грн");
                Console.WriteLine($"Додатково 5 % від перевищення ({excess:F2} грн): {extraTax:F2} грн");
                Console.WriteLine($"Військовий збір {MilitaryRate:P1}: {militaryTax:F2} грн");
                Console.WriteLine($"На руки: {netIncome:F2} грн");

                // ===== Рівень Б =====
                // Гілка з when стоїть вище за загальнішу з таким самим діапазоном
                bool isOverThreshold = income > Threshold;
                string category = netIncome switch
                {
                    < 3000 => "низький дохід",
                    >= 3000 and < 8000 when isOverThreshold => "середній дохід (діє підвищена ставка)",
                    >= 3000 and < 8000 => "середній дохід",
                    _ => "високий дохід"
                };
                Console.WriteLine($"Категорія: {category}");
            }
        }
    }
}