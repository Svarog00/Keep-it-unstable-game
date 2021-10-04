using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] private ReactionController _reactionController;
    private TMP_Text _textField;

    private void Start()
    {
        _textField = GetComponent<TMP_Text>();
        _reactionController.OnNucleeExploded += _reactionController_OnNucleeExploded;
        _reactionController.OnLoseEventHandler += _reactionController_OnLoseEventHandler;
    }

    private void _reactionController_OnLoseEventHandler(object sender, System.EventArgs e)
    {
        _textField.text = "";
    }

    private void _reactionController_OnNucleeExploded(object sender, ReactionController.OnNucleeExplodedEventArgs e)
    {
        _textField.text = e.Score.ToString();
    }
}
