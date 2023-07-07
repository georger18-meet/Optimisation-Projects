using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce = 50f;


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
        GameObject proj = Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(proj.transform.forward * _shootForce, ForceMode.Impulse);
        Destroy(proj, 2.5f);
    }
}
