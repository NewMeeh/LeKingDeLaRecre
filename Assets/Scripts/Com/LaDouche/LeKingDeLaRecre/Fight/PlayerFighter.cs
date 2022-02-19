using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    public class PlayerFighter : Fighter
    {

        private Attack _selectedAttack;

        public Attack SelectedAttack
        {
            get => _selectedAttack;
            set => _selectedAttack = value;
        }

        public void Select(int i)
        {
            _selectedAttack = _attacks[i];
        }
        
        public override Attack NextAttack() => _selectedAttack;
        
        
    }
}
