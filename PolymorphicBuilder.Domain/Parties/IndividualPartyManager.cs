namespace PolymorphicBuilder.Domain.Parties;

public interface IIndividualPartyManager<TSelf, TParty> : IIndividualPartyOptions,
    IPartyManager<TSelf, TParty>
    where TSelf : IIndividualPartyManager<TSelf, TParty>
    where TParty : IIndividualPartyOptions
{
    public TSelf WithNationalCode(string nationalCode);
}

public abstract class IndividualPartyManager<TSelf, TParty> :
    PartyManager<TSelf, TParty>,
    IIndividualPartyManager<TSelf, TParty>
    where TSelf : IIndividualPartyManager<TSelf, TParty>
    where TParty : IIndividualPartyOptions
{
    public string NationalCode { get; private set; }

    public TSelf WithNationalCode(string nationalCode)
    {
        NationalCode = nationalCode;
        return this;
    }
}

public class IndividualPartyManager : IndividualPartyManager<IndividualPartyManager, IndividualParty>
{
}