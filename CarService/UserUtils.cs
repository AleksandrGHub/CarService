namespace CarService
{
    class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandomNumber(int minNumber, int maxNumber)
        {
            return _random.Next(minNumber, maxNumber);
        }

        public static int GetRandomNumber(int number)
        {
            return _random.Next(number);
        }
    }
}