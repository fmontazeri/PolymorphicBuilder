using System.Diagnostics;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Parties;

public class IndividualParty : Party, IIndividualPartyOptions
{
    public string NationalCode { get; set; }

    public IndividualParty(IIndividualPartyOptions options) : base(options)
    {
        GuardAgainstNullOrEmptyNationalCode(options.NationalCode);
        this.NationalCode = options.NationalCode;
    }


    private void GuardAgainstNullOrEmptyNationalCode(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new ArgumentNullException(nameof(NationalCode));
    }
    
    
}