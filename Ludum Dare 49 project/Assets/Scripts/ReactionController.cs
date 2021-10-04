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
    public event EventHandler<OnNucleeExplodedEventArgs> OnNucleeExploded;
    public class OnNucleeExplodedEventArgs : EventArgs
    {
        public int Score;
    }

    [SerializeField] private float _time;
    private int _score;
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
        _curTime += mass/3;
        OnNucleeExploded?.Invoke(this, new OnNucleeExplodedEventArgs { Score = mass });    
    }
}
