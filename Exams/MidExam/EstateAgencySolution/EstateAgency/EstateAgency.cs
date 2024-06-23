using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public int Capacity { get; set; }
        public List<RealEstate> RealEstates { get; set; }
        // коментарите са мои
        // тук съм го изписал с return realEastates.Count;
        public int Count => RealEstates.Count;

        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates = new List<RealEstate>();
        }

        // тук по различен начин съм го изписал 
        public bool AddRealEstate(RealEstate realEstate)
        {
            if (this.RealEstates.Any(r => r.Address == realEstate.Address))
            {
                return false;
            }
            if (Count < Capacity)
            {
                RealEstates.Add(realEstate);
                return true;
            }
            return false;
        }
        // тук съм ползвал .Find
        public bool RemoveRealEstate(string address)
        {
            RealEstate realEstate = RealEstates.FirstOrDefault(r => r.Address == address);
            if (realEstate != null)
            {
                RealEstates.Remove(realEstate);
                return true;
            }
            return false;
        }
        // използвам съм FindAll не Where
        public List<RealEstate> GetRealEstates(string postalCode)
        {
            return RealEstates.Where(r => r.PostalCode == postalCode).ToList();
        }

        // тук не съм ползвал FirstOrDefailt което няма да ми връща цял лист а само най-евтиния
        public RealEstate GetCheapest()
        {
            return RealEstates.OrderBy(r => r.Price).FirstOrDefault();
        }
        // същото нещо става и тук използвам .ToList(); вместо .FirstOrDefault() и после .Size за да взема което искам
        public double GetLargest()
        {
            return RealEstates.OrderByDescending(r => r.Size).FirstOrDefault().Size;
        }

        public string EstateReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Real estates available:");
            foreach (var realEstate in RealEstates)
            {
                sb.AppendLine(realEstate.ToString());
            }
            return sb.ToString().Trim(); // тук не съм го .Trim() И може за това да ми е правил грешки
        }
        // това изобщо не съм го записвал
        public RealEstate GetRealEstate(string address)
        {
            return RealEstates.FirstOrDefault(r => r.Address == address);
        }
    }
}
