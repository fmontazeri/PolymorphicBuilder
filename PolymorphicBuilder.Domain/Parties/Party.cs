using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Parties;

public class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        GuardAgainstNullOrEmptyName(options.Name);
        this.Name = options.Name;
    }

    public string Name { get; private set; }

    private void GuardAgainstNullOrEmptyName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(Name));
    }

    public void Update(IPartyOptions options)
    {
        this.Name = options.Name;
    }
}