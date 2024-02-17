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
        this.Constructor_Should_Create_Party_Successfully();

        //Act
        var sut = TestManager.Build();

        //Assert
        sut.Should().BeEquivalentTo(TestManager.SutBuilder);
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
        var sut = TestManager.WithName(name);

        //Assert
        sut.SutBuilder.Should().BeEquivalentTo(TestManager.SutBuilder);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_Throw_Exception_When_NationalCode_Is_Null_Or_Empty(string nationalCode)
    {
        //Arrange
        TestManager.SutBuilder.WithNationalCode(nationalCode);

        //Act
        Action action = () => { TestManager.SutBuilder.Build(); };

        //Assert
        action.Should().Throw<ArgumentNullException>(nameof(TestManager.SutBuilder.NationalCode));
    }

    protected override TestPartyManager<TestIndividualPartyManager, IndividualPartyManager, IndividualParty> CreateInstance()
    {
        return new TestIndividualPartyManager();
    }
}