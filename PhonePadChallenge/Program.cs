using PhonePadChallenge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PhonePadChallenge
{
    internal class Program
    {
        private static IServiceProvider CreateServices<T>()
        {
            var services = new ServiceCollection();
            
            services.AddTransient(typeof(IPhonePadConverter), typeof(T));
            
            return services.BuildServiceProvider();
        }

        static void Main(string[] args)
        {
            var linqServices = CreateServices<OldPhonePadLinqConverter>();
            var iterativeServices = CreateServices<OldPhonePadIterativeConverter>();
            
            var linqConverter = linqServices.GetRequiredService<IPhonePadConverter>();
            Console.WriteLine("\n----------------- Run Convert tests using LinqConverter -----------------");
            RunConvertTests(linqConverter);
            
            var iterativeConverter = iterativeServices.GetRequiredService<IPhonePadConverter>();
            Console.WriteLine("\n----------------- Run Convert tests using IterativeConverter -----------------");
            RunConvertTests(iterativeConverter);
            
            Console.WriteLine("\n----------------- Run Reverse tests --------------");
            RunReverseTests(iterativeConverter);
        }

        private static void RunConvertTests(IPhonePadConverter converter)
        {
            var convertTestCases = new[]
            {
                "222 2 22#",              // CAB
                "33#",                    // E
                "3322#",                  // EB
                "227*#",                  // B
                "8 88777444666*664#",     // TURING
                "4433555 555666096667775553#",  // HELLO WORLD
            };

            foreach (var test in convertTestCases)
            {
                Console.WriteLine($"Input: {test} -> Output: {converter.Convert(test)}");
            }
        }

        private static void RunReverseTests(IPhonePadConverter converter)
        {
            var reverseTestCases = new[]
            {
                "CAB",
                "E",
                "EB",
                "B",
                "TURING",
                "HELLO WORLD",
            };
            
            foreach (var test in reverseTestCases)
            {
                Console.WriteLine($"Input: {test} -> Output: {converter.Reverse(test)}");
            }
        }
    }
}