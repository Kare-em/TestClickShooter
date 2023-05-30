using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _damage;
    private Rigidbody _rb;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyController.TakeDamage(_damage);
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BulletZone"))
            gameObject.SetActive(false);
    }

    public void Release(float speed, float damage)
    {
        _rb.velocity = transform.forward * speed;
        _damage = damage;
    }
}