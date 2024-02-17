namespace PolymorphicBuilder.Domain.Parties;

public class IndividualParty : Party , IIndividualPartyOptions
{
    public string NationalCode { get; set; }

    public IndividualParty(IIndividualPartyOptions options) : base(options)
    {
        this.NationalCode = options.NationalCode;
    }
}