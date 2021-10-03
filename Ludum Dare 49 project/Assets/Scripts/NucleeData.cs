using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "NucleeData", menuName = "NucleeData", order = 0)]
    public class NucleeData : ScriptableObject
    {
        [SerializeField] private List<Sprite> _sprites;

    }
}