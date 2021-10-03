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
    public event EventHandler OnNucleeExploded;

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
        else
        {
            
        }
    }

    public void RefreshTimer(int mass)
    {
        _curTime += mass/2;
        OnNucleeExploded?.Invoke(this, EventArgs.Empty);
    }
}
