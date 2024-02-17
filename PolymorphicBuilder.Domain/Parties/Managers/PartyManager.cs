using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Parties.Managers;

public interface IPartyManager<TSelf, TParty>  : IPartyOptions
    where TParty : IPartyOptions
    where TSelf : IPartyManager<TSelf, TParty>
{
    TParty Build();
    TSelf WithName(string name);
}

public abstract class PartyManager<TSelf, TParty> : IPartyManager<TSelf, TParty>
    where TParty : IPartyOptions
    where TSelf : IPartyManager<TSelf, TParty>
{
    public TParty Build()
    {
        try
        {
            return (TParty)Activator.CreateInstance(typeof(TParty), this)!;
        }
        catch (Exception e)
        {
            throw e.InnerException;
        }
    }

    public string Name { get; private set; }

    public TSelf WithName(string name)
    {
        this.Name = name;
        return this;
    }
    
    public static implicit operator TSelf(PartyManager<TSelf, TParty> manager)
    {
        return (TSelf)(IPartyManager<TSelf, TParty>)manager;
    }
}