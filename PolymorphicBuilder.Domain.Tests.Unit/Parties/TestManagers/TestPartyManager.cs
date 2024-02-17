using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

public abstract class TestPartyManager<TSelf, TManager, TParty>
    where TSelf : TestPartyManager<TSelf, TManager, TParty>
    where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    public string Name => Name;
    protected abstract TManager CreateManger();
    public TManager ActualBuilder;

    protected TestPartyManager()
    {
        ActualBuilder = CreateManger();
        ActualBuilder.WithName("sample party");
    }

    public TParty Build()
    {
        return ActualBuilder.Build();
    }

    public TSelf WithName(string name)
    {
        ActualBuilder.WithName(name);
        return this;
    }

    public void Update(TParty options)
    {
        ActualBuilder.Update(options);
    }

    public static implicit operator TSelf(TestPartyManager<TSelf, TManager, TParty> self) => (self as TSelf)!;
}

public class TestPartyManager : TestPartyManager<TestPartyManager, DummyTargetManager, PartyTest>
{
    protected override DummyTargetManager CreateManger()
    {
        return new DummyTargetManager();
    }
}