using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

public abstract class TestPartyManager<TManager, TParty>
    where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    public string Name => Name;
    protected abstract TManager CreateManger();
    public TManager SUT;

    protected TestPartyManager()
    {
        SUT = CreateManger();
        SUT.WithName("sample party");
    }


    public TParty Build()
    {
        return SUT.Build();
    }
}

public class TestPartyManager : TestPartyManager<DummyTargetManager, PartyTest>
{
    protected override DummyTargetManager CreateManger()
    {
        return new DummyTargetManager();
    }
}