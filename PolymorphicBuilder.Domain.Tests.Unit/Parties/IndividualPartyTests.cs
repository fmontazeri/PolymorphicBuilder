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
        SUT = TestManager.Build();

        //Assert
        SUT.Should().BeEquivalentTo(TestManager.ActualBuilder);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public override void Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_Null(string name)
    {
        //Arrange
        base.Constructor_Should_Throw_Exception_When_Name_Is_Empty_Or_Null(name);

        //Act
        Action action = () => TestManager.WithName(name).Build();

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.Name));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_Throw_Exception_When_NationalCode_Is_Null_Or_Empty(string nationalCode)
    {
        //Arrange
        TestManager.ActualBuilder.WithNationalCode(nationalCode);

        //Act
        Action action = () => { TestManager.ActualBuilder.Build(); };

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.ActualBuilder.NationalCode));
    }


    [Theory]
    [InlineData("sample 3")]
    [InlineData("sample 4")]
    public override void Update_Should_Be_Done_When_Name_Will_Be_Changed(string name)
    {
        //Arrange
        base.Update_Should_Be_Done_When_Name_Will_Be_Changed(name);
        SUT = TestManager.WithName(name).Build();

        //Act
        TestManager.Update(SUT);

        //Assert
        SUT.Should().BeEquivalentTo(TestManager.ActualBuilder);
    }

    protected override TestPartyManager<TestIndividualPartyManager, IndividualPartyManager, IndividualParty> CreateInstance()
    {
        return new TestIndividualPartyManager();
    }
}