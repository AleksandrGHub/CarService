namespace CarService
{
    class Warehouse
    {
        private Random _random = new Random();
        private List<Cell> _cells = new List<Cell>();

        public Warehouse()
        {
            AddDetails();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Список деталей на складе");
            Console.WriteLine("{0,12}{1,21}{2,20}{3,20}{4,20}", "Номер детали", "Название детали", "Цена", "Стоимость услуги", "Колличество деталей");

            for (int i = 0; i < _cells.Count; i++)
            {
                Console.WriteLine("{0,12}{1,21}{2,20}{3,20}{4,20}", i + 1, _cells[i].Detail.Name, _cells[i].Detail.Cost, _cells[i].Detail.CostReplace, _cells[i].Number);
            }
        }

        public bool TryDecreaseCount(int index)
        {
            bool canDecrease = false;

            if (_cells[index].Number > 0)
            {
                canDecrease = true;

                _cells[index].DecreaseNumber();
            }

            return canDecrease;
        }

        public Detail GetDetail(int index)
        {
            return _cells[index].Detail;
        }

        public int GetCellsCount()
        {
            return _cells.Count;
        }

        private void AddDetails()
        {
            int minNumberDetails = 2;
            int maxNumberDetails = 5;

            Catalog catalog = new Catalog();

            for (int i = 0; i < catalog.GetCount(); i++)
            {
                _cells.Add(new Cell(catalog.GetDetail(i).Clone(isBroken: false), _random.Next(minNumberDetails, maxNumberDetails)));
            }
        }
    }
}