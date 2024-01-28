namespace CarService
{
    class Car
    {
        private int _money = 100000;

        public Car(Detail detail)
        {
            Detail = detail;
        }

        public Detail Detail { get; private set; }

        public void SetDetail(Detail detail)
        {
            Detail = detail;
        }

        public void DecreaseMoney(int money)
        {
            _money -= money;
        }

        public void AddMoneyPenalty(int costPenalty)
        {
            _money += costPenalty;
        }

        public void ShowInfo()
        {
            string state = Detail.IsBroken ? "поломана" : "целая";

            Console.WriteLine("Деталь: {0,0} - {1,9}. Стоимость детали:{2,6} руб. Стоимость ремонта:{3,6} руб.", Detail.Name, state, Detail.Cost, Detail.CostReplace);
        }
    }
}