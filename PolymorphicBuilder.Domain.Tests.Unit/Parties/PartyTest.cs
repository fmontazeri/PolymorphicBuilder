
using PolymorphicBuilder.Domain.Parties;
using PolymorphicBuilder.Domain.Parties.Options;

namespace PolymorphicBuilder.Domain.Tests.Unit.Parties;

public class PartyTest(IPartyOptions options) : Party(options);