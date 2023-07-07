using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce = 50f;

    [SerializeField] private bool _useObjectPooling;
    [SerializeField] private int _amountToPool;
    [SerializeField] private List<GameObject> _pooledObjects = new List<GameObject>();
    private PoolHolder _poolParent;

    private void Start()
    {
        _poolParent = PoolHolder.Instance;
        if (_useObjectPooling) CreatePool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }


    private void ShootProjectile()
    {
        if (!_useObjectPooling)
        {
            ProjectileInstantiated();
        }
        else
        {
            ProjectilePooled();
        }
    }

    private void ProjectileInstantiated()
    {
        GameObject proj = Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation, _poolParent.transform);
        Destroyer destroyer = proj.GetComponent<Destroyer>();
        destroyer.UseDestroy = true;
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(proj.transform.forward * _shootForce, ForceMode.Impulse);
    }

    private void ProjectilePooled()
    {
        GameObject bullet = GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = _shootPoint.rotation;
            bullet.SetActive(true);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * _shootForce, ForceMode.Impulse);
        }
    }

    private void CreatePool()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_projectile, _poolParent.transform);
            obj.SetActive(false);
            _pooledObjects.Add(obj);

            Destroyer destroyer = obj.GetComponent<Destroyer>();
            destroyer.UseDestroy = false;
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
