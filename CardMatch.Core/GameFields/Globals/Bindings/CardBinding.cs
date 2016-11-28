using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields.Globals.Bindings
{
    public class CardBinding
    {
        public string Identifier { get; set; }
        public ICard Card { get; set; }
    }
}
