using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartenspiel
{
    public interface IGameView
    {
        void UpdateView();

        string GetUserInput();

        void AccounceWinner();

    }
}
