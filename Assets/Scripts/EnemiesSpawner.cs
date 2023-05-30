using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] public bool AutoSpawm=true;
    [SerializeField] private float _time = 1f;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _player;
    
    private Pool _pool;

    private void OnEnable()
    {
        _pool = GetComponent<Pool>();
    }

    private void Start()
    {
        _pool = GetComponent<Pool>();
        StartCoroutine(AutoSpawn());
    }

    private void OnDrawGizmos()
    {
        foreach (var point in _points)
        {
            Gizmos.DrawSphere(point.position, 1f);
        }
    }

    private IEnumerator AutoSpawn()
    {
        while (AutoSpawm)
        {
            yield return new WaitForSeconds(_time);
            Spawn();
        }
    }

    public void Spawn()
    {
        var enemy = _pool.GetActivatedObject();
        enemy.GetComponent<EnemyController>().SetPlayer(_player);
        enemy.transform.position = _points[Random.Range(0, _points.Count)].position;
    }
}