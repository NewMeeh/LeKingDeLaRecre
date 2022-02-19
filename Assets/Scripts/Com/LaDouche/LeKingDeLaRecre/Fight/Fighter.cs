using System.Collections.Generic;
using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    public abstract class Fighter : MonoBehaviour
    {
        [SerializeField] private Stats _stats;
        [SerializeField] private string _name;
        [SerializeField] protected List<Attack> _attacks;
        public Stats Stats => _stats;

        public bool IsGud => _stats.Hp > 0;

        public void OnTatkZebi(Attack attack)
        {
            _stats.Hp -= attack.Damage;
        }
        
        
        public abstract Attack NextAttack();
    }
}