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
        SUT.Should().BeEquivalentTo(TestManager.ActualBuilder);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public virtual void Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_Null(string name)
    {
        //Arrange
        TestManager.WithName(name);

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
        SUT = TestManager.WithName(name).Build();

        //Act
        TestManager.Update(SUT);

        //Assert
        SUT.Should().BeEquivalentTo(TestManager.ActualBuilder);
    }
}

public class PartyTests : PartyTests<TestPartyManager, DummyTargetManager, PartyTest>
{
    protected override TestPartyManager<TestPartyManager, DummyTargetManager, PartyTest> CreateInstance()
    {
        return new TestPartyManager();
    }
}