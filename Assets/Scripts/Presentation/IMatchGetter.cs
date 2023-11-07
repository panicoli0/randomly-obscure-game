using CardMatchingGame.UI.View;
using System.Collections.Generic;

namespace CardMatchingGame.Presentation
{
    public interface IMatchGetter
    {
        void CheckMatch(List<CardView> cards);
    }
}

