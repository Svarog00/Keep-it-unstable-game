using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextContorller : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private ReactionController _reactionController;

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
