using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _playField;
    private Nuclee _startNuclee;
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _startNuclee = GetComponentInChildren<Nuclee>();
        _startNuclee.IsUnstable = true;
        _playField.SetActive(false);
        _startNuclee.OnExplodeEventHandler += _startNuclee_OnExplodeEventHandler;
    }

    private void _startNuclee_OnExplodeEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
    {
        _animator.Play("StartScreenDisappear");
    }

    public void Disappear()
    {
        _playField.SetActive(true);
        gameObject.SetActive(false);
    }
}
