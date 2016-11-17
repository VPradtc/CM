using CardMatch.Core.Models;

namespace CardMatch.Core.GameFields
{
    public class GameField<TCard, TContext>
    {
        private static object __lock = new object();
        private static GameField<TCard, TContext> __instance;

        public static GameField<TCard, TContext> Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (__lock)
                    {
                        if (__instance == null)
                        {
                            __instance = new GameField<TCard, TContext>();
                        }
                    }
                }

                return __instance;
            }
        }

        private TCard[,] _field;

        public TContext Context { get; set; }

        protected GameField()
        {
        }

        public void SetField(TCard[,] field)
        {
            _field = field;
        }
    }
}
