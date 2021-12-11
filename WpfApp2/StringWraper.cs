using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalckJack_Wpf
{
    public class StringWraper
    {
        List<string> _playerListToWrap;
        public StringWraper(List<string> playerListToWrap)
        {
            this.PlayerListToWrap = playerListToWrap;
        }
        public List<string> PlayerListToWrap
        {
            get { return _playerListToWrap; }
            set { _playerListToWrap = value; }
        }
    }
}
