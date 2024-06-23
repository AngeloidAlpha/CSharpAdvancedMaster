using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        private List<RealEstate> realEastates;
        private int capacity;
        private int count;

        public EstateAgency(int capacity)
        {
            this.realEastates = new List<RealEstate>();
            this.capacity = capacity;
            this.Count = count;
        }

        public List<RealEstate> RealEstates { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return realEastates.Count;
            }
            set
            {
                count = value;
            }
        }
        // от решената задача тук започна да чупи много крайни проверки с public bool 
        public void AddRealEstate(RealEstate realEstate)
        {
            if (realEastates.Count < capacity)
            {
                // may error
                if (!realEastates.Contains(realEstate))
                {
                    realEastates.Add(realEstate);
                }
            }
        }
        public bool RemoveRealEstate(string address)
        {
            bool result = false;
            // moje da se 4upi
            // .Find съм ползвал сменено на .FirstOrDefault // не намери проблем
            RealEstate removeRealEstate = realEastates.Find(x => x.Address == address);
            if (removeRealEstate != null)
            {
                result = realEastates.Remove(removeRealEstate);
            }
            return result;
        }
        public List<RealEstate> GetRealEstates(string postalCode)
        {
            // .Where и накрая .ToList() // не намери проблем
            return realEastates.FindAll(x => x.PostalCode == postalCode);
        }
        public RealEstate GetCheapest()
        {
            //return RealEstates.OrderBy(r => r.Price).FirstOrDefault(); // това тук чупи пред пред последното V
            var cheepestRealEstate = realEastates.OrderBy(x => x.Price).ToList();
            return cheepestRealEstate[0];
        }
        public double GetLargest()
        {
            //return RealEstates.OrderByDescending(r => r.Size).FirstOrDefault().Size; // това тук бриква предпоследния V
            var cheepestRealEstate = realEastates.OrderByDescending(x => x.Size).ToList();
            return cheepestRealEstate[0].Size;
        }
        public string EstateReport()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Real estates available:");
            foreach (var realEstate in realEastates)
            {
                stats.AppendLine(realEstate.ToString());
            }
            return stats.ToString().Trim(); // .Trim() добавих и фиксва един от последните x 71/100
        }
    }
}

// непоправен код 64/100 - V V V V X X X X V V V V V X
// променях кода отдолу нагоре
// .Trim() добавих и фиксва последния Х 71/100 - V V V V X X X X V V V V V V
// всяко друго нещо не направи никаква промяна даже повече и повече грешки в крайните проверки

