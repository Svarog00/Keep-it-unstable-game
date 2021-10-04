using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private ReactionController _reactionController;
    [SerializeField] private GameObject _visual;

    // Start is called before the first frame update
    void Start()
    {
        _reactionController.OnLoseEventHandler += _reactionController_OnLoseEventHandler;
        _visual.SetActive(false);
    }

    private void _reactionController_OnLoseEventHandler(object sender, System.EventArgs e)
    {
        _visual.SetActive(true);
    }
}
