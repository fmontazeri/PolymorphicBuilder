using FluentAssertions;
using PolymorphicBuilder.Domain.Parties;
using PolymorphicBuilder.Domain.Parties.Managers;
using PolymorphicBuilder.Domain.Tests.Unit.Parties.TestManagers;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public class IndividualPartyTests : PartyTests<TestIndividualPartyManager, IndividualPartyManager, IndividualParty>
{
    [Fact]
    public void Constructor_Should_Create_IndividualParty_Successfully()
    {
        //Arrange
        Constructor_Should_Create_Party_Successfully();

        //Act
        SUT = TestManager.ActualManager.Build();

        //Assert
        SUT.Should().BeEquivalentTo(TestManager.ActualManager);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public override void Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_WhiteSpace(string name)
    {
        //Arrange
        base.Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_WhiteSpace(name);

        //Act
        Action action = () => TestManager.ActualManager.WithName(name).Build();

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.Name));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_Throw_Exception_When_NationalCode_Is_Null_Or_WhiteSpace(string nationalCode)
    {
        //Arrange
        TestManager.ActualManager.WithNationalCode(nationalCode);

        //Act
        Action action = () => { TestManager.ActualManager.Build(); };

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.ActualManager.NationalCode));
    }


    [Theory]
    [InlineData("sample 3")]
    [InlineData("sample 4")]
    public override void Update_Should_Be_Done_When_Name_Changed(string name)
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

    protected override TestPartyManager<TestIndividualPartyManager, IndividualPartyManager, IndividualParty>
        CreateInstance()
    {
        return new TestIndividualPartyManager();
    }
}