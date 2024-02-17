using FluentAssertions;
using PolymorphicBuilder.Domain.Parties;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public class IndividualPartyTests : PartyTests<IndividualPartyManager, IndividualParty>
{
    [Fact]
    public void Constructor_Should_Create_IndividualParty_Successfully()
    {
        //Act
        var sut = Manager.Build();

        //Assert
        sut.Should().BeEquivalentTo(Manager.SutBuilder);
    }


    protected override TestPartyManager<IndividualPartyManager, IndividualParty> CreateInstance()
    {
        return new TestIndividualPartyManager();
    }
}