using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _playField;
    private Nuclee _startNuclee;

    // Start is called before the first frame update
    void Start()
    {
        _startNuclee = GetComponentInChildren<Nuclee>();
        _startNuclee.IsUnstable = true;
        _playField.SetActive(false);
        _startNuclee.OnExplodeEventHandler += _startNuclee_OnExplodeEventHandler;
    }

    private void _startNuclee_OnExplodeEventHandler(object sender, Nuclee.OnExplodeEventArgs e)
    {
        _playField.SetActive(true);
        gameObject.SetActive(false);
    }
}
