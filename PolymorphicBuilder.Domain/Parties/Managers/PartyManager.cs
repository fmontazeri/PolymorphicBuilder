using System.Reflection;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Parties.Managers;

public interface IPartyManager<TSelf, TParty> : IPartyOptions
    where TParty : IPartyOptions
    where TSelf : IPartyManager<TSelf, TParty>
{
    TParty Build();
    TSelf WithName(string name);
    void Update(TParty options);
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

    public void Update(TParty options)
    {
        var type = options.GetType();
        while (type is not null)
        {
            var methodInfo = type
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .SingleOrDefault(info => info.DeclaringType == type && info.Name == "Update");

            if (methodInfo is not null)
            {
                InvokeUpdateMethod(options, methodInfo);
                break;
            }

            type = type.BaseType;
        }
    }

    private void InvokeUpdateMethod(TParty sut, MethodInfo methodInfo)
    {
        try
        {
            methodInfo.Invoke(sut, new object[] { sut });
        }
        catch (Exception e)
        {
            throw e.InnerException;
        }
    }

    public static implicit operator TSelf(PartyManager<TSelf, TParty> manager)
    {
        return (TSelf)(IPartyManager<TSelf, TParty>)manager;
    }
}