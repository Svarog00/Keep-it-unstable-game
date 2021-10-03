using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleeAnimator : MonoBehaviour
{
    private Animator _animator;
    private Nuclee _nuclee;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _nuclee = GetComponent<Nuclee>();
        _nuclee.OnUnstableEventHandler += _nuclee_OnUnstableEventHandler;
        _nuclee.OnExplodeEventHandler += _nuclee_OnExplodeEventHandler;
    }

    private void _nuclee_OnExplodeEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
    {
        //Play explode animation
        throw new System.NotImplementedException();
    }

    private void _nuclee_OnUnstableEventHandler(object sender, System.EventArgs e)
    {
        //Unstable animation trigger set
        throw new System.NotImplementedException();
    }
}
