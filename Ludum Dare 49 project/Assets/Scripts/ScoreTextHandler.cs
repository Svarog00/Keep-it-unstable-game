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
        _reactionController.OnTimeRefreshEventHandler += _reactionController_OnTimeRefreshEventHandler;
    }

    private void _reactionController_OnTimeRefreshEventHandler(object sender, ReactionController.OnTimeRefreshEventArgs e)
    {
        _textField.text = e.Time.ToString("0.00");
    }
}
