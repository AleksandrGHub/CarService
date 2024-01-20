namespace CarService
{
    class Menu
    {
        private const string ServeCommand = "Обслужить";
        private const string RefuseCommand = "Отказать";

        private Service _servise = new Service();

        public void Work()
        {
            string? userInput;

            for (int i = 0; i < _servise.GetCountClients(); i++)
            {
                Console.Clear();

                _servise.ShowInfo();
                _servise.ShowClients();

                _servise.ShowClint(i);
                Console.WriteLine("\nВведите команду: {0,10} или {1,10}", ServeCommand, RefuseCommand);

                do
                {
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case ServeCommand:
                            _servise.Serve(i);
                            break;

                        case RefuseCommand:
                            _servise.Refuse(i);
                            break;
                    }
                }
                while (userInput != ServeCommand & userInput != RefuseCommand);

                if (i == _servise.GetCountClients()-1)
                {
                    Console.Clear();

                    _servise.ShowInfo();
                    _servise.ShowClients();
                }
            }
        }
    }
}