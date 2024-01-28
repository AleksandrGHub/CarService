namespace CarService
{
    class Catalog
    {
        private Random _random = new Random();
        private Detail[] _details;

        public Catalog()
        {
            _details =
            [
            new Detail("бампер",cost: 15000,costReplace: 500,false),
            new Detail("генератор",cost: 12000,costReplace: 4000,false),
            new Detail("глушитель",cost: 22000,costReplace: 4500,false),
            new Detail("замок",cost: 2600,costReplace: 2000,false),
            new Detail("катушка зажигания",cost: 6500,costReplace: 2500,false),
            new Detail("КПП",cost: 45000,costReplace: 9000,false),
            new Detail("крыло",cost: 17000,costReplace: 7000,false),
            new Detail("лампочка",cost: 100,costReplace: 200,false),
            new Detail("прокладка",cost: 2500,costReplace: 6000,false),
            new Detail("распредвал",cost: 25000,costReplace: 14000,false),
            new Detail("сайлентблок",cost : 250, costReplace : 400,false),
            new Detail("суппорт",cost: 9000,costReplace: 3500,false),
            new Detail("тормозная колодка",cost: 3000,costReplace: 2000,false),
            new Detail("тормозные диски",cost: 5000,costReplace: 4000,false),
            new Detail("шаровая",cost : 1500, costReplace : 1500,false),
            ];
        }

        public Detail GetDetail(int index)
        {
            return _details[index];
        }

        public Detail GetRandomDetail()
        {
            return GetDetail(_random.Next(_details.Length));
        }

        public int GetCount()
        {
            return _details.Length;
        }
    }
}