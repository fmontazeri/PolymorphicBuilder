namespace PolymorphicBuilder.Domain.Parties.Options;

public interface IIndividualPartyOptions : IPartyOptions
{
    public string NationalCode { get; }
}