using System;
using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    [Serializable]
    public class Stats
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _attack;
        [SerializeField] private int _defense;
        [SerializeField] private int _speed;

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }
        public int Attack => _attack;
        public int Defense => _defense;
        public int Speed => _speed;
    }
}