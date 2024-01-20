namespace CarService
{
    class Cell
    {
        public Detail Detail { get; private set; }
        public int Number { get; private set; }

        public Cell(Detail detail, int number)
        {
            Detail = detail;
            Number = number;
        }

        public void SetDetail(Detail detail)
        {
            Detail = detail;
        }

        public void SetNumber(int number)
        {
            Number = number;
        }

        public void DecreaseNumber()
        {
            if (Number > 0)
            {
                Number--;
            }
            else
            {
                Console.WriteLine("Детали закончились!");
            }
        }
    }
}