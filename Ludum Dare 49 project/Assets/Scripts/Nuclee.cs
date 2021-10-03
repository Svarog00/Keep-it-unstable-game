using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Nuclee : MonoBehaviour, IPoolable
{
    public event EventHandler OnUnstableEventHandler;
    public event EventHandler OnGrowEventHandler;
    public event EventHandler<OnExplodeEventArgs> OnExplodeEventHandler;

    public class OnExplodeEventArgs : EventArgs
    {
        public float NucleeMass;
    }

    public ReactionController ReactionController;

    private ObjectPool _objectPool;
    [SerializeField] private GameObject _particlePrefab;

    [SerializeField] private bool _isUnstable;
    [SerializeField] private int _mass;
    [SerializeField] private float _halfLifeTime;
    private float _curTime;

    public bool IsUnstable
    {
        set => _isUnstable = value;
    }

    private void Start()
    {
        _curTime = _halfLifeTime;
    }

    private void Update()
    {
        if(!_isUnstable)
        {
            _curTime -= Time.deltaTime;
        }
        if (_curTime <= 0 && _isUnstable == false)
        {
            Decay();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Particle"))
        {
            if(_isUnstable)
            {
                Explode();
            }
            else
            {
                Grow();
            }
        }
    }

    private void Decay()
    {
        int rnd = UnityEngine.Random.Range(0, 100);
        if(rnd < 50 && _isUnstable == false)
        {
            _isUnstable = true;
            Debug.Log($"Unstable!!!!");
            OnUnstableEventHandler?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            _curTime = _halfLifeTime;
            Debug.Log($"Stable.");
        }
    }

    public void Explode()
    {
        if(_isUnstable)
        {
            GenerateParticles();
            CameraShake.Instance.ShakeCamera(_mass, 0.4f);
            ReactionController.RefreshTimer(_mass);
            OnExplodeEventHandler?.Invoke(this, new OnExplodeEventArgs { NucleeMass = _mass });
            ReturnToPool();
        }
    }

    private void Grow()
    {
        _mass++;
        if(!_isUnstable)
        {
            _curTime = _halfLifeTime;
            OnGrowEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GenerateParticles()
    {
        for(int i = 0; i < _mass; i++)
        {
            GameObject particle = Instantiate(_particlePrefab);
            particle.transform.position = transform.position;
            Vector2 randDir = UtilitiesClass.GetRandomDir();
            particle.GetComponent<Particle>().Direction = randDir;
        }
    }

    public void ReturnToPool()
    {
        _objectPool.AddToPool(gameObject);
    }

    public void SetPool(ObjectPool pool)
    {
        _objectPool = pool;
    }
}