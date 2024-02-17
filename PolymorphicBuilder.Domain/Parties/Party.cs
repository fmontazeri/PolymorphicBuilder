using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Parties;

public   class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        this.Name = options.Name;
    }

    public string Name { get; private set; }
}