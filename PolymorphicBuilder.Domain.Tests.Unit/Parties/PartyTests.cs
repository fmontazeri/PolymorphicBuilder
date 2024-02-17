using FluentAssertions;
using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;
using PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public abstract class PartyTests<TManager, TParty> where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    protected abstract TestPartyManager<TManager, TParty> CreateInstance();
    protected TestPartyManager<TManager, TParty> TestManager;

    public PartyTests()
    {
        TestManager = CreateInstance();
    }

    [Fact]
    public void Constructor_Should_Create_Party_Successfully()
    {
        //Act
        var sut = TestManager.Build();

        //Assert
        sut.Should().BeEquivalentTo(TestManager);
    }
}

public class PartyTests : PartyTests<DummyTargetManager, PartyTest>
{
    protected override TestPartyManager<DummyTargetManager, PartyTest> CreateInstance()
    {
        return new TestPartyManager();
    }
}