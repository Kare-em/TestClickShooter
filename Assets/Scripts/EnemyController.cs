using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : EntityController
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _damageInterval = 1f;

    private NavMeshAgent _agent;
    private Transform _player;
    private bool _isAttacking = false;

    private float _currentReloadingTime;
    private bool _isShooting = false;
    private float _lastShotTime = 0.0f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Init();
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    private void Update()
    {
        if (!IsDead && !_isAttacking)
        {
            FollowPlayer();
        }

        if (_isAttacking)
            AttackPlayer();
    }

    private void FollowPlayer()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isAttacking = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isAttacking = false;
        }
    }

    private void AttackPlayer()
    {
        if (Time.time - _lastShotTime >= _damageInterval)
        {
            _player.GetComponent<PlayerController>().TakeDamage(_damage);
            _lastShotTime = Time.time;
        }
    }


    protected override void Die()
    {
        IsDead = true;
        _agent.enabled = false;
        Destroy(gameObject, 0.2f);
    }
}