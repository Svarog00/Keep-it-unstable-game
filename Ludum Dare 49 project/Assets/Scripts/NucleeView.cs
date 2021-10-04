using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MassType { Heavy, Medium, Light }

public class NucleeView : MonoBehaviour
{
    private const string GROW_ANIMATION = "Grow";
    private const string UNSTABLE_ANIMATION = "Unstable";
    private const string IDLE_ANIMATION = "Idle";

    [SerializeField] private Nuclee _nucleeModel;
    [SerializeField] private SpriteRenderer _curSprite;
    private NucleeData _nucleeSprites;
    private MassType _currMassType;

    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    
    private void Awake()
    {
        _nucleeModel = GetComponentInParent<Nuclee>();
        _nucleeModel.OnGrowEventHandler += _nucleeModel_OnGrowEventHandler;
        _nucleeModel.OnUnstableEventHandler += _nuclee_OnUnstableEventHandler;

        _nucleeSprites = _nucleeModel.NucleeData;
        //Get animator variant
        _animator = GetComponent<Animator>();
        _curSprite = GetComponent<SpriteRenderer>();

    }

    void Start()
    {
        _animator.Play(IDLE_ANIMATION);
    }

    private void _nuclee_OnGrowEventHandler(object sender, System.EventArgs e)
    {
        _animator.Play(GROW_ANIMATION + _currMassType.ToString());
    }

    private void _nuclee_OnUnstableEventHandler(object sender, System.EventArgs e)
    {
        _animator.Play(UNSTABLE_ANIMATION + _currMassType.ToString());
    }

    private void _nucleeModel_OnGrowEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
    {
        if(e.NucleeMass < 3)
        {
            _currMassType = MassType.Light;
        }
        else if (e.NucleeMass >= 3 && e.NucleeMass <= 5)
        {
            _currMassType = MassType.Medium;
        }
        else if(e.NucleeMass > 5)
        {
            _currMassType = MassType.Heavy;
        }

        _curSprite.sprite = _nucleeSprites.Sprites[(int)_currMassType];
    }
}
