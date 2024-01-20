namespace CarService
{
    class Car
    {
        public Car()
        {
            AddDetail();
        }

        public Detail Detail { get; private set; }

        public Car Clone()
        {
            return new Car();
        }

        public void SetDetail(Detail detail)
        {
            Detail = detail;
        }

        public void ShowInfo()
        {
            string state = Detail.IsBroken ? "поломана" : "целая";

            Console.WriteLine("Деталь: {0,0} - {1,9}. Стоимость детали:{2,6} руб. Стоимость ремонта:{3,6} руб.", Detail.Name, state, Detail.Cost, Detail.CostReplace);
        }

        private void AddDetail()
        {
            Catalog catalog = new Catalog();

            Detail = catalog.GetRandomDetail().Clone(isBroken: true);
        }
    }
}