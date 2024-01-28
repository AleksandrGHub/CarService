namespace CarService
{
    class Warehouse
    {
        private List<Cell> _cells = new List<Cell>();

        public Warehouse()
        {
            AddDetails();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Список деталей на складе");
            Console.WriteLine($"{"Номер детали",12}{"Название детали",21}{"Цена",20}{"Стоимость услуги",20}{"Колличество деталей",20}");

            for (int i = 0; i < _cells.Count; i++)
            {
                Console.WriteLine($"{i + 1,12}{_cells[i].Detail.Name,21}{_cells[i].Detail.Cost,20}{_cells[i].Detail.CostReplace,20}{_cells[i].Number,20}");
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
                _cells.Add(new Cell(catalog.GetDetail(i).Clone(isBroken: false), UserUtils.GetRandomNumber(minNumberDetails, maxNumberDetails)));
            }
        }
    }
}