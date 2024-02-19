using PolymorphicBuilder.Domain.Parties;
using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

public abstract class TestIndividualPartyManager<TSelf, TManager, TParty> : TestPartyManager<TSelf, TManager, TParty>
    where TSelf : TestIndividualPartyManager<TSelf, TManager, TParty>
    where TManager : IIndividualPartyManager<TManager, TParty>
    where TParty : IIndividualPartyOptions;

public class TestIndividualPartyManager : TestIndividualPartyManager<TestIndividualPartyManager, IndividualPartyManager,
    IndividualParty>
{
    public TestIndividualPartyManager()
    {
        ActualManager.WithNationalCode("123456789");
    }

    public string NationalCode => ActualManager.NationalCode;

    protected override IndividualPartyManager CreateManager()
    {
        return new IndividualPartyManager();
    }

    public TestIndividualPartyManager WithNationalCode(string nationalCode)
    {
        ActualManager.WithNationalCode(nationalCode);
        return this;
    }
}