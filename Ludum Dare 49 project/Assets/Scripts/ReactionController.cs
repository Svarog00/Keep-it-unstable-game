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

    public event EventHandler OnLoseEventHandler;

    public event EventHandler<OnTimeCoeffUpEventHandlerEventArgs> OnTimeCoeffUpEventHandler;
    public class OnTimeCoeffUpEventHandlerEventArgs : EventArgs
    {
        public float TimeCoeff;
    }


    [SerializeField] private float _time;
    private int _curScore = 0;
    private int _prevScore = 0;
    private float _curTime;
    private float _timeCoeff = 1;
    [SerializeField] private float _timeMultiplier;

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
            _curTime -= Time.deltaTime * _timeCoeff;
            OnTimeRefreshEventHandler?.Invoke(this, new OnTimeRefreshEventArgs { Time = _curTime });
        }
        else
        {
            OnLoseEventHandler?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        }
    }

    public void RefreshTimer(int mass)
    {
        _curTime += mass/3;
        _curScore += mass;
        if(_curScore - _prevScore >= 100)
        {
            _prevScore = _curScore;
            _timeCoeff += _timeMultiplier;
            OnTimeCoeffUpEventHandler?.Invoke(this, new OnTimeCoeffUpEventHandlerEventArgs { TimeCoeff = _timeCoeff });
        }
        OnNucleeExploded?.Invoke(this, new OnNucleeExplodedEventArgs { Score = _curScore });    
    }
}
