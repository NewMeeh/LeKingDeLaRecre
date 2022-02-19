using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    public class BotFighter : Fighter
    {
        public override Attack NextAttack() => _attacks[Random.Range(0, _attacks.Count)];
    }
}