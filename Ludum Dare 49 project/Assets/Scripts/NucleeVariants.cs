using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "NucleeVariants", menuName = "NucleeVariants", order = 0)]
    public class NucleeVariants : ScriptableObject
    {
        [SerializeField] private NucleeData[] _nucleeDatas = new NucleeData[4];

        public NucleeData GetRandomVariant()
        {
            return _nucleeDatas[Random.Range(0, 4)];
        }
    }
}