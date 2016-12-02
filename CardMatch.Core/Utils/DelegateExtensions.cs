using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.Utils
{
    public static class DelegateExtensions
    {
        public static void SafeInvoke(this EventHandler eventHandler, object o, EventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(o, args);
            }
        }

        public static void SafeInvoke<T>(this EventHandler<T> eventHandler, object o, T args)
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(o, args);
            }
        }
    }
}
