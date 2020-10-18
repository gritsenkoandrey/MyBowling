using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Pool/ObjectPooling")]
public sealed class ObjectPooling
{
    private List<PoolObject> _objects;
    private Transform _objectsParent;

    private void Addobject(PoolObject sample, Transform objectsParent)
    {
        var temp = GameObject.Instantiate(sample.gameObject);
        temp.name = sample.name;
        temp.transform.SetParent(objectsParent);
        _objects.Add(temp.GetComponent<PoolObject>());

        if (temp.GetComponent<Animator>())
        {
            temp.GetComponent<Animator>().StartPlayback();
        }

        temp.SetActive(false);
    }

    public void Initialize(int count, PoolObject sample, Transform objectsParent)
    {
        _objects = new List<PoolObject>();
        _objectsParent = objectsParent;
        for (int i = 0; i < count; i++)
        {
            Addobject(sample, objectsParent);
        }
    }

    public PoolObject GetObject()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].gameObject.activeInHierarchy == false)
            {
                return _objects[i];
            }
        }
        Addobject(_objects[0], _objectsParent);
        return _objects[_objects.Count - 1];
    }
}