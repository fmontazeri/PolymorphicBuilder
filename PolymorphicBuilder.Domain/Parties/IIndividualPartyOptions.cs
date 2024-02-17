namespace PolymorphicBuilder.Domain.Parties;

public interface IIndividualPartyOptions : IPartyOptions
{
    public string NationalCode { get; }
}