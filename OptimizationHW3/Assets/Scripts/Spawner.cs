using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjToSpawn;
    public Vector3 Size;

    // Update is called once per frame
    void Update()
    {
        if (ObjToSpawn != null) StartCoroutine(SpawnObj());
    }

    IEnumerator SpawnObj()
    {
        float randSpawnTime = Random.Range(0f, 2);

        yield return new WaitForSeconds(randSpawnTime);

        float randX = Random.Range(-Size.x, Size.x);
        float randZ = Random.Range(-Size.z, Size.z);

        Vector3 randPos = new Vector3(randX, 0, randZ);

        GameObject tempObj = Instantiate(ObjToSpawn, transform.position + randPos, Quaternion.identity);

        float randDestroyTime = Random.Range(5, 10);
        Destroy(tempObj, randDestroyTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Size);
    }
}
