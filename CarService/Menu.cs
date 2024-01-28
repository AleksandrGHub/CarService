namespace CarService
{
    class Menu
    {
        private const string ServeCommand = "Обслужить";
        private const string RefuseCommand = "Отказать";

        private Service _servise = new Service();

        public void Work()
        {
            string userInput;

            while (_servise.GetCountCars() > 0)
            {
                Console.Clear();

                _servise.ShowInfo();

                Console.WriteLine($"\nВведите команду: {ServeCommand} или {RefuseCommand}");

                do
                {
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case ServeCommand:
                            _servise.Serve();
                            break;

                        case RefuseCommand:
                            _servise.Refuse();
                            break;
                    }
                }
                while (userInput != ServeCommand & userInput != RefuseCommand);
            }
        }
    }
}