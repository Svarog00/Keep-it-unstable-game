using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleeClickHandler : MonoBehaviour
{
    [SerializeField] private Nuclee _nuclee;

    private void OnMouseUp()
    {
        _nuclee.Explode();
    }
}
