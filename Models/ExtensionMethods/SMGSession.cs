using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Models.ExtensionMethods
{
    public class SMGSession
    {
        private const string PhyKet = "myPhysicians";
        private const string CountKey = "physcount";
        private const string TownsKey = "town";
        private const string SpecsKey = "spec";
        private const string GensKey = "gen";

        private ISession session { get; set; }
        public SMGSession(ISession session) => this.session = session;

        public void SetMyPhyc(List<Physician> physicians)
        {
            session.SetObject(PhyKet, physicians);
            session.SetInt32(CountKey, physicians.Count);
        }
        public List<Physician> GetMyPhyc() =>
            session.GetObject<List<Physician>>(PhyKet) ?? new List<Physician>();
        public int? GetMyPhycCount() => session.GetInt32(CountKey);

        public void SetActiveSpecs(string activeSpec) =>
            session.SetString(SpecsKey, activeSpec);
        public string GetActiveSpecs() =>
            session.GetString(SpecsKey) ?? string.Empty;

        public void SetActiveGens(string activeGen) =>
            session.SetString(GensKey, activeGen);
        public string GetActiveGens() =>
            session.GetString(GensKey) ?? string.Empty;
        public void SetActiveTowns(string activeTown) =>
            session.SetString(TownsKey, activeTown);
        public string GetActiveTowns() =>
            session.GetString(TownsKey) ?? string.Empty;

        public void RemoveMyPhyc()
        {
            session.Remove(PhyKet);
            session.Remove(CountKey);
        }
    }
}