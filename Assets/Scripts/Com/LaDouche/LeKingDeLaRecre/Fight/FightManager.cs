using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    public class FightManager : MonoBehaviour
    {
        [SerializeField] private Fighter Fighter1;
        [SerializeField] private Fighter Fighter2;

        [Button]
        public void PlayTurn()
        {
            if (!CheckGud()) return;
            ExecuteAttacks();
        }

        private void ExecuteAttacks()
        {
            Fighter first;
            Fighter second;
            if (Fighter1.Stats.Speed >= Fighter2.Stats.Speed)
            {
                first = Fighter1;
                second = Fighter2;
            }
            else
            {
                first = Fighter2;
                second = Fighter1;
            }
            second.OnTatkZebi(first.NextAttack());
            if (!CheckGud()) return;
            first.OnTatkZebi(second.NextAttack());
            CheckGud();
        }

        private bool CheckGud()
        {
            if (!Fighter1.IsGud)
            {
                EndFight(Fighter2);
                return false;
            }
            if (!Fighter2.IsGud)
            {
                EndFight(Fighter1);
                return false;
            }
            return true;
        }
        
        private void EndFight(Fighter winner)
        {
            Debug.Log(winner.name + " won !");
        }
    }
}