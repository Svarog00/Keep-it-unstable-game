using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NucleeAudio : MonoBehaviour
    {
        private Nuclee _nucleeModel;

        private void Start()
        {
            _nucleeModel = GetComponent<Nuclee>();
            _nucleeModel.OnExplodeEventHandler += _nucleeModel_OnExplodeEventHandler;
            _nucleeModel.OnGrowEventHandler += _nucleeModel_OnGrowEventHandler;
        }

        private void _nucleeModel_OnGrowEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _nucleeModel_OnExplodeEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}