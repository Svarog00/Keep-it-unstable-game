using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionController : MonoBehaviour
{
    public event EventHandler<OnTimeRefreshEventArgs> OnTimeRefreshEventHandler;
    public class OnTimeRefreshEventArgs : EventArgs
    {
        public float Time;
    }

    [SerializeField] private float _time;
    private float _curTime;

    // Start is called before the first frame update
    void Start()
    {
        _curTime = _time;
    }

    // Update is called once per frame
    void Update()
    {
        if(_curTime > 0)
        {
            _curTime -= Time.deltaTime;
            OnTimeRefreshEventHandler?.Invoke(this, new OnTimeRefreshEventArgs { Time = _curTime });
        }
    }

    public void RefreshTimer()
    {
        _curTime = _time;
    }
}
