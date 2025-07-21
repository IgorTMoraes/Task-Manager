using static System.Net.Mime.MediaTypeNames;

namespace TaskManager.Services
{
    public class PomodoroService
    {
        public int pomodoroTime = 25;
        public int shortBreakTime = 5;
        public int longBreakTime = 15;

        private const int secondsConverts = 60; // Conversão de minutos para segundos

        public int pomodoroCount = 0;


        // Método principal que executa o ciclo Pomodoro infinitamente.
        // Alterna entre trabalho, intervalo curto e intervalo longo.
        public void Main(string[] args)
        {
            while (true) // Loop 
            {
                // Inicia um ciclo de trabalho 
                Console.WriteLine($"\nPomodoro {pomodoroCount + 1}: Tempo de trabalho iniciado.");
                Countdown(pomodoroTime * secondsConverts); // Converte minutos em segundos

                pomodoroCount++; // Incrementa o contador

                if (pomodoroCount < 4)
                {
                    // Entre os primeiros 3 ciclos, intervalo curto
                    Console.WriteLine("\nIniciando Intervalo Curto.");
                    Countdown(shortBreakTime * secondsConverts);
                }
                else 
                {
                    // Após o 4º ciclo, intervalo longo e reset do contador
                    Console.WriteLine("\nIniciando Intervalo Longo.");
                    Countdown(longBreakTime * secondsConverts);
                    pomodoroCount = 0; // Reset após o Long Break
                }
            }
        }

        // Exibe um contador regressivo no console com base no tempo em segundos.
        public void Countdown(int seconds)
        {
            for (int i = seconds; i >= 0; i--)
            {
                // Exibe o tempo restante de forma atualizada no console
                string output = $"Tempo restante: {i} segundos";
                Console.WriteLine($"\r{output.PadRight(40)}");
                Thread.Sleep(1000); // Espera 1 segundo entre as atualizações
            }
            Console.WriteLine("\nTempo finalizado!");
        }

    }
}