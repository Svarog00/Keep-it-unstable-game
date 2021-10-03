using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleeView : MonoBehaviour
{
    private Nuclee _nucleeModel;
    private Sprite _curSprite;
    private NucleeData _nucleeSprites;

    private void Start()
    {
        _nucleeModel.OnGrowEventHandler += _nucleeModel_OnGrowEventHandler;
        _curSprite = GetComponent<Sprite>();
    }

    private void SetSprite()
    {

    }

    private void _nucleeModel_OnGrowEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
    {
        if (e.NucleeMass >= 3)
        {
            
        }
        else if(e.NucleeMass > 5)
        {

        }
    }
}
