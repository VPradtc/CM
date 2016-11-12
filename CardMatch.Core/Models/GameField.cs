
namespace CardMatch.Core.Models
{
    public class GameField
    {
        private static object __lock;

        private static GameField __instance;

        private Card[,] _field;

        protected GameField()
        {
        }

        public static GameField Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (__lock)
                    {
                        if (__instance == null)
                        {
                            __instance = new GameField();
                        }
                    }
                }

                return __instance;
            }
        }

        public void SetField(Card[,] field)
        {
            _field = field;
        }
    }
}
