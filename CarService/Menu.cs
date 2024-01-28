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

            bool hasKeywords;

            while (_servise.GetCountCars() > 0)
            {
                Console.Clear();

                _servise.ShowInfo();

                Console.WriteLine($"\nВведите команду: {ServeCommand} или {RefuseCommand}");

                do
                {
                    hasKeywords = true;
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case ServeCommand:
                            _servise.ServeCar();
                            break;

                        case RefuseCommand:
                            _servise.RefuseCar();
                            break;

                        default:
                            hasKeywords = false;
                            break;
                    }
                }
                while (hasKeywords == false);
            }
        }
    }
}