using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _thrust;
    [SerializeField] private float _lifeTime;
    private Vector2 _direction;

    public Vector2 Direction
    {
        set => _direction = value;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _direction * _thrust;
    }
}
