using FluentAssertions;
using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Parties.Options;
using PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public abstract class PartyTests<TTestManager, TManager, TParty> where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
    where TTestManager : TestPartyManager<TTestManager, TManager, TParty>
{
    protected abstract TestPartyManager<TTestManager, TManager, TParty> CreateInstance();
    protected TestPartyManager<TTestManager, TManager, TParty> TestManager;
    protected TParty SUT;
    

    public PartyTests()
    {
        TestManager = CreateInstance();
    }

    [Fact]
    public void Constructor_Should_Create_Party_Successfully()
    {
        //Act
        SUT = TestManager.Build();

        //Assert
        SUT.Should().BeEquivalentTo(TestManager.ActualManager);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public virtual void Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_WhiteSpace(string name)
    {
        //Arrange
        TestManager.ActualManager.WithName(name);

        //Act
        Action action = () => TestManager.Build();

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.Name));
    }

    [Theory]
    [InlineData("sample 1")]
    [InlineData("sample 2")]
    public virtual void Update_Should_Be_Done_When_Name_Changed(string name)
    {
        //Arrange
        Constructor_Should_Create_Party_Successfully();
        TestManager.ActualManager.WithName(name);

        //Act
        TestManager.ActualManager.Update(SUT);

        //Assert
        SUT.Name.Should().Be(name);
        SUT.Should().BeEquivalentTo(TestManager.ActualManager);
        
    }
}

public class PartyTests : PartyTests<TestPartyManager, DummyPartyManager, PartyTest>
{
    protected override TestPartyManager<TestPartyManager, DummyPartyManager, PartyTest> CreateInstance()
    {
        return new TestPartyManager();
    }
}