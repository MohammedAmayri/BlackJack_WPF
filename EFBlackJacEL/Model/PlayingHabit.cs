using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlackJacEL.Model
{
    
    public class PlayingHabit
    {
       
        #region fields
        int noGameDays;
        int moneySpent;
        int _habitID;
        Random random = new Random();

        #endregion
        public int NoGameDays
        {
            set { noGameDays = value; }
            get { return noGameDays; }
        }
        public int MoneySpent
        {
            set { moneySpent = value; }
            get { return moneySpent; }
        }
        [Key]
        public int HabitId
        {
            get => _habitID;
            set { _habitID = random.Next(1, 10000);}
        }

        #region Constructor
        public PlayingHabit(int noGameDays, int moneySpent)
        {
            this.noGameDays = noGameDays;
            this.moneySpent = moneySpent;
        }
        #endregion
    }
}
