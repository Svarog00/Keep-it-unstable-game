using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Nuclee : MonoBehaviour, IPoolable
{
    public event EventHandler OnUnstableEventHandler;
    public event EventHandler<OnExplodeEventArgs> OnGrowEventHandler;

    public event EventHandler<OnExplodeEventArgs> OnExplodeEventHandler;
    public class OnExplodeEventArgs : EventArgs
    {
        public float NucleeMass;
    }

    public ReactionController ReactionController;

    private ObjectPool _objectPool;
    private NucleeData _nucleeData;

    private float _curTime;

    [SerializeField] private NucleeVariants _nucleeVariants;
    [SerializeField] private GameObject _particlePrefab;

    [SerializeField] private bool _isUnstable;
    [SerializeField] private int _mass;
    [SerializeField] private float _halfLifeTime;


    public bool IsUnstable
    {
        set
        {
            _isUnstable = value;
            OnUnstableEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }

    public NucleeData NucleeData
    {
        get => _nucleeData;
        set => _nucleeData = value;
    }

    private void Awake()
    {
        _curTime = _halfLifeTime;
        _nucleeData = _nucleeVariants.GetRandomVariant();
        _nucleeData = Instantiate(_nucleeData);

        GameObject gameObject = Instantiate(_nucleeData.AnimatorPrefab, transform);
        gameObject.transform.position = transform.position;

        _particlePrefab = _nucleeData.ParticlePrefab;
        _mass = UnityEngine.Random.Range(1, 7);
    }

    private void OnEnable()
    {
        _mass = UnityEngine.Random.Range(1, 7);
        OnGrowEventHandler?.Invoke(this, new OnExplodeEventArgs { NucleeMass = _mass });
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
                Destroy(collision.gameObject);
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
            _isUnstable = false;

            if(_objectPool != null)
            {
                ReturnToPool();
            }
            else
            {
                gameObject.SetActive(false);
            }

            GenerateParticles();
            CameraShake.Instance.ShakeCamera(_mass/1.5f, 0.4f);
            if(ReactionController != null)
            {
                ReactionController.RefreshTimer(_mass);
            }
            OnExplodeEventHandler?.Invoke(this, new OnExplodeEventArgs { NucleeMass = _mass });
            FindObjectOfType<AudioManager>().Play("NucleeExplode");
        }
    }

    private void Grow()
    {
        _mass++;
        if(!_isUnstable)
        {
            _curTime = _halfLifeTime;
            FindObjectOfType<AudioManager>().Play("NucleeGrow");
            OnGrowEventHandler?.Invoke(this, new OnExplodeEventArgs { NucleeMass = _mass });
        }
    }

    private void GenerateParticles()
    {
        for (int i = 0; i < _mass; i++)
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