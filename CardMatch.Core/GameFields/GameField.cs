using CardMatch.Core.Models;

namespace CardMatch.Core.GameFields
{
    public class GameField<TCard>
    {
        private static object __lock = new object();
        private static GameField<TCard> __instance;

        public static GameField<TCard> Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (__lock)
                    {
                        if (__instance == null)
                        {
                            __instance = new GameField<TCard>();
                        }
                    }
                }

                return __instance;
            }
        }

        private TCard[,] _field;

        public IGameFieldContext Context { get; set; }

        protected GameField()
        {
        }

        public void SetField(TCard[,] field)
        {
            _field = field;
        }
    }
}
