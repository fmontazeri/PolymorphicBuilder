using PolymorphicBuilder.Domain.Parties;
using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

public abstract class TestIndividualPartyManager<TManager, TParty> : TestPartyManager<TManager, TParty>
    where TManager : IIndividualPartyManager<TManager, TParty> 
    where TParty : IIndividualPartyOptions;

public class TestIndividualPartyManager : TestIndividualPartyManager<IndividualPartyManager, IndividualParty>
{
    public TestIndividualPartyManager()
    {
        SutBuilder.WithNationalCode("123456789");
    }

    public string NationalCode => SutBuilder.NationalCode;

    public override IndividualPartyManager CreateManger()
    {
        return new IndividualPartyManager();
    }
}