using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleeAnimator : MonoBehaviour
{
    private const string GROW_ANIMATION = "Grow";
    private const string UNSTABLE_ANIMATION = "Unstable";
    private const string IDLE_ANIMATION = "Idle";

    [SerializeField] private Animator _animator;
    private Nuclee _nuclee;

    // Start is called before the first frame update
    void Start()
    {
        _nuclee = GetComponent<Nuclee>();

        _nuclee.OnUnstableEventHandler += _nuclee_OnUnstableEventHandler;
        _nuclee.OnGrowEventHandler += _nuclee_OnGrowEventHandler;
    }

    private void _nuclee_OnGrowEventHandler(object sender, System.EventArgs e)
    {
        _animator.Play(IDLE_ANIMATION, (int)MassType.Heavy);
    }

    private void _nuclee_OnUnstableEventHandler(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(UNSTABLE_ANIMATION);
    }
}
