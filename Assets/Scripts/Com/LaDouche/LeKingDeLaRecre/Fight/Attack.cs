using UnityEngine;

namespace Com.LaDouche.LeKingDeLaRecre.Fight
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Object/Attack")]
    public class Attack : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _damage;
        [SerializeField] private bool _fear;
        [SerializeField] private bool _stinky;
        [SerializeField] private bool _slow;

        public string Name => _name;
        public int Damage => _damage;
        public bool Fear => _fear;
        public bool Stinky => _stinky;
        public bool Slow => _slow;
    }
}