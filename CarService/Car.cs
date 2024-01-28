namespace CarService
{
    class Car
    {
        private int _money = 100000;

        public Car(Detail detail)
        {
            Detail = detail;
            _money = 100000;
            CostPenalty = 2000;
        }

        public Detail Detail { get; private set; }
        public int CostPenalty { get; private set; }

        public void SetDetail(Detail detail)
        {
            Detail = detail;
        }

        public void DecreaseMoney(Checklist checklist)
        {
            _money -= checklist.TotalCost;
        }

        public void AddMoneyPenalty()
        {
            _money += CostPenalty;
        }

        public void ShowInfo()
        {
            string state = Detail.IsBroken ? "поломана" : "целая";

            Console.WriteLine("Деталь: {0,0} - {1,9}. Стоимость детали:{2,6} руб. Стоимость ремонта:{3,6} руб.", Detail.Name, state, Detail.Cost, Detail.CostReplace);
        }
    }
}