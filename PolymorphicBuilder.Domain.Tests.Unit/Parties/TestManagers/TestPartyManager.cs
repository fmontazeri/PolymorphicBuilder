using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

public abstract class TestPartyManager<TSelf, TManager, TParty>
    where TSelf : TestPartyManager<TSelf, TManager, TParty>
    where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    public string Name => ActualManager.Name;
    protected abstract TManager CreateManager();
    public TManager ActualManager;

    protected TestPartyManager()
    {
        ActualManager = CreateManager();
        ActualManager.WithName("sample party");
    }

    public TParty Build()
    {
        return ActualManager.Build();
    }

    public static implicit operator TSelf(TestPartyManager<TSelf, TManager, TParty> self) => (self as TSelf)!;
}

public class TestPartyManager : TestPartyManager<TestPartyManager, DummyPartyManager, PartyTest>
{
    protected override DummyPartyManager CreateManager()
    {
        return new DummyPartyManager();
    }
}