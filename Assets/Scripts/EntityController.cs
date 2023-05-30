using System;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [HideInInspector] public bool IsDead = false;
    [SerializeField] protected int _maxHealth = 50;
    [SerializeField] protected float _moveSpeed = 5.0f;
    protected float _currentHealth;

    protected void Init()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        
    }
}