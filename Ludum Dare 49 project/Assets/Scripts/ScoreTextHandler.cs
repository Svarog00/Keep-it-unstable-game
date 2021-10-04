using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] private ReactionController _reactionController;
    private TMP_Text _textField;
    private int _score = 0;

    private void Start()
    {
        _textField = GetComponent<TMP_Text>();
        _reactionController.OnNucleeExploded += _reactionController_OnNucleeExploded;
    }

    private void _reactionController_OnNucleeExploded(object sender, ReactionController.OnNucleeExplodedEventArgs e)
    {
        _textField.text = e.Score.ToString();
    }
}
