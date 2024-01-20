namespace CarService
{
    class Client
    {
        public Client()
        {
            AddCar();
            Money = 100000;
            IsServe = false;
            CostPenalty = 2000;
        }

        public Car Car { get; private set; }
        public int Money { get; private set; }
        public bool IsServe { get; private set; }
        public int CostPenalty { get; private set; }

        public void DecreaseMoney(Checklist checklist)
        {
            Money -= checklist.TotalCost;
        }

        public void AddMoneyPenalty()
        {
            Money += CostPenalty;
        }

        public Client Clone()
        {
            return new Client();
        }

        public void Serve()
        {
            IsServe = true;
        }

        private void AddCar()
        {
            Car = new Car().Clone();
        }
    }
}