using PolymorphicBuilder.Domain.Parties;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public abstract class TestPartyManager<TManager, TParty>
    where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    public string Name => Name;
    public abstract TManager CreateManger();
    public TManager SutBuilder;

    public TestPartyManager()
    {
        SutBuilder = CreateManger();
        SutBuilder.WithName("sample party");
    }


    public TParty Build()
    {
        return SutBuilder.Build();
    }
}

public class TestPartyManager : TestPartyManager<DummyTargetManager, PartyTest>
{
    public override DummyTargetManager CreateManger()
    {
        return new DummyTargetManager();
    }
}