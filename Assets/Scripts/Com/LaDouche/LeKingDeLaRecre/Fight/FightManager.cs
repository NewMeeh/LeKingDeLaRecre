using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    public class FightManager : MonoBehaviour
    {
        [SerializeField] private Fighter fighter1;
        [SerializeField] private Fighter fighter2;
        [SerializeField] private Text gameText;
        [SerializeField] private Text fighter1Name;
        [SerializeField] private Text fighter2Name;
        [SerializeField] private Slider fighter1HealthBar;
        [SerializeField] private Slider fighter2HealthBar;

        private Queue<string> logs = new Queue<string>();

        private void OnEnable()
        {
            if (fighter1 != null && fighter2 != null)
                InitFight(fighter1, fighter2);
        }

        public void InitFight(Fighter f1, Fighter f2)
        {
            fighter1 = f1;
            fighter1Name.text = f1.Name;
            fighter2 = f2;
            fighter2Name.text = f2.Name;
            logs.Clear();
            updateHealth();
            gameText.text = "";
        }
        
        [Button]
        public void PlayTurn()
        {
            if (!CheckGud()) return;
            ExecuteAttacks();
        }

        private void PutInLogs(string s)
        {
            if (logs.Count >= 4)
            {
                logs.Dequeue();
            }
            logs.Enqueue(s);
            gameText.text = String.Join("\n", logs);
        }

        private void ExecuteAttacks()
        {
            Fighter first;
            Fighter second;
            if (fighter1.Stats.Speed >= fighter2.Stats.Speed)
            {
                first = fighter1;
                second = fighter2;
            }
            else
            {
                first = fighter2;
                second = fighter1;
            }
            second.OnTatkZebi(first.NextAttack());
            PutInLogs(first.Name + " utilise " + first.NextAttack().name + " sur " + second.Name);
            updateHealth();
            if (!CheckGud()) return;
            first.OnTatkZebi(second.NextAttack());
            PutInLogs(second.Name + " utilise " + second.NextAttack().name + " sur " + first.Name);
            updateHealth();
            CheckGud();
        }

        private void updateHealth()
        {
            fighter1HealthBar.value = 1f * fighter1.Stats.Hp / fighter1.Stats.MaxHp;
            fighter2HealthBar.value = 1f * fighter2.Stats.Hp / fighter2.Stats.MaxHp;
        }

        private bool CheckGud()
        {
            if (!fighter1.IsGud)
            {
                EndFight(fighter2);
                return false;
            }
            if (!fighter2.IsGud)
            {
                EndFight(fighter1);
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