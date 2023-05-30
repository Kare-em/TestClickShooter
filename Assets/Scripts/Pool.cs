using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;
    [SerializeField] private int _addCount = 3;
    private List<GameObject> _pool;

    private void OnEnable()
    {
        _pool = new List<GameObject>();
        Spawn(_count);
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObject = Instantiate(_prefab);
            newObject.SetActive(false);
            _pool.Add(newObject);
        }
    }

    private void OnDisable()
    {
        _pool.Clear();
    }

    public GameObject GetActivatedObject()
    {
        var item = GetObject();
        item.SetActive(true);
        return item;
    }

    public GameObject GetObject()
    {
        foreach (var item in _pool)
        {
            if (item != null && !item.activeInHierarchy)
            {
                return item;
            }
        }

        Spawn(_addCount);
        return GetObject();
    }

}