namespace CarService
{
    class Service
    {
        private List<Client> _clients = new List<Client>();

        private Warehouse _warehouse = new Warehouse();

        private List<Checklist> _checklist = new List<Checklist>();

        private int _money = 1000000;

        public Service()
        {
            AddClients();
        }

        public void ShowInfo()
        {
            Console.WriteLine("***************************************** Автосервис ****************************************");
            Console.WriteLine($"Деньги автосервиса: {_money} руб.");
        }

        public void ShowClients()
        {
            int orderNumber = 1;

            Console.WriteLine("{0,13}{1,20}{2,20}{3,20}{4,20}", "Номер клиента", "Название детали", "Деньги клиента", "Итоговая стоимость", "Статус услуги");

            foreach (Client client in _clients)
            {
                Console.WriteLine("{0,13}{1,20}{2,20}{3,20}{4,20}", orderNumber++, client.Car.Detail.Name, Convert.ToString(client.Money) + " руб.", Convert.ToString(client.Car.Detail.Cost + client.Car.Detail.CostReplace) + " руб.", client.IsServe ? "оказана" : "не оказана");
            }
        }

        public void ShowClint(int index)
        {
            Console.WriteLine($"\nКлиент {index + 1}");
            _clients[index].Car.ShowInfo();
        }

        public void Serve(int index)
        {
            int indexDetail;

            _warehouse.ShowInfo();

            indexDetail = GetNumber() - 1;

            if (_warehouse.TryDecreaseCount(indexDetail))
            {
                Client client = _clients[index];
                Detail detail = _warehouse.GetDetail(indexDetail).Clone(isBroken: false);
                Checklist checklist = new Checklist(client);

                if (client.Car.Detail.Name == detail.Name)
                {
                    client.Car.SetDetail(detail);
                    client.Serve();
                    client.DecreaseMoney(checklist);

                    _checklist.Add(checklist);

                    _money += checklist.TotalCost;
                }
                else
                {
                    client.Car.SetDetail(detail);
                    Refuse(index);
                }
            }
            else
            {
                Refuse(index);
            }
        }

        public void Refuse(int index)
        {
            _clients[index].AddMoneyPenalty();

            _money -= _clients[index].CostPenalty;
        }

        public int GetCountClients()
        {
            return _clients.Count;
        }

        private int GetNumber()
        {
            int number;

            do { Console.WriteLine("Укажите номер детали из списка!"); }
            while (!Int32.TryParse(Console.ReadLine(), out number) | !(number >= 1) | !(number <= _warehouse.GetCellsCount()));
            return number;
        }

        private void AddClients()
        {
            Client client = new Client();

            int numberClients = 5;

            for (int i = 0; i < numberClients; i++)
            {
                _clients.Add(client.Clone());
            }
        }
    }
}