using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTextHandler : MonoBehaviour
{
    [SerializeField] private ReactionController _reactionController;
    private TMP_Text _textField;

    private void Start()
    {
        _textField = GetComponent<TMP_Text>();
        _reactionController.OnTimeRefreshEventHandler += _reactionController_OnTimeRefreshEventHandler;
        _reactionController.OnLoseEventHandler += _reactionController_OnLoseEventHandler;
    }

    private void _reactionController_OnLoseEventHandler(object sender, System.EventArgs e)
    {
        _textField.text = "";
    }


    private void _reactionController_OnTimeRefreshEventHandler(object sender, ReactionController.OnTimeRefreshEventArgs e)
    {
        _textField.text = e.Time.ToString("0.00");
        if(e.Time < 5f)
        {
            _textField.color = Color.red;
        }
        else
        {
            _textField.color = Color.green;
        }
    }
}
