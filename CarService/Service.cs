namespace CarService
{
    class Service
    {
        private List<Car> _cars = new List<Car>();
        private List<Checklist> _checklists = new List<Checklist>();
        private Warehouse _warehouse = new Warehouse();
        private int _money = 1000000;
        private int _costPenalty = 2000;

        public Service()
        {
            AddCars();
        }

        public void ShowInfo()
        {
            Console.WriteLine("*************************************** Автосервис **************************************");
            Console.WriteLine($"Деньги автосервиса: {_money} руб.\n");
            _cars[0].ShowInfo();
        }

        public void ServeCar()
        {
            int index;

            _warehouse.ShowInfo();

            index = GetNumber() - 1;

            if (_warehouse.TryDecreaseCount(index))
            {
                Car car = _cars[0];
                Detail detail = _warehouse.GetDetail(index).Clone(isBroken: false);
                Checklist checklist = new Checklist(car);

                if (car.Detail.Name == detail.Name)
                {
                    car.SetDetail(detail);
                    car.DecreaseMoney(checklist.TotalCost);

                    _checklists.Add(checklist);

                    _money += checklist.TotalCost;

                    _cars.RemoveAt(index: 0);
                }
                else
                {
                    car.SetDetail(detail);
                    RefuseCar();
                }
            }
            else
            {
                RefuseCar();
            }
        }

        public void RefuseCar()
        {
            _cars[0].AddMoneyPenalty(_costPenalty);

            _money -= _costPenalty;

            _cars.RemoveAt(index: 0);
        }

        public int GetCountCars()
        {
            return _cars.Count;
        }

        private int GetNumber()
        {
            int number;

            do
            {
                Console.WriteLine("Укажите номер детали из списка!");
            }
            while (Int32.TryParse(Console.ReadLine(), out number) == false | (number >= 1) == false | (number <= _warehouse.GetCellsCount()) == false);

            return number;
        }

        private void AddCars()
        {
            Catalog catalog = new Catalog();

            int numberCars = 5;

            for (int i = 0; i < numberCars; i++)
            {
                _cars.Add(new Car(catalog.GetRandomDetail().Clone(isBroken: true)));
            }
        }
    }
}