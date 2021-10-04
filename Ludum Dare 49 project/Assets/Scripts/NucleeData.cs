using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "NucleeData", menuName = "NucleeData", order = 0)]
    public class NucleeData : ScriptableObject
    {
        [SerializeField] private Sprite[] _sprites = new Sprite[3];
        [SerializeField] private GameObject _particlePrefab;
        [SerializeField] private GameObject _animatorPrefab;

        public GameObject ParticlePrefab
        {
            get => _particlePrefab;
        }

        public Sprite[] Sprites
        {
            get => _sprites;
        }

        public GameObject AnimatorPrefab
        {
            get => _animatorPrefab;
        }
    }
}