using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public Transform Parent;
    public float TimeTaken;

    private float startTime;
    private float endTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjects();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    [ContextMenu("Create Objects")]
    public void CreateObjects()
    {
        int counter = 0;
        startTime = Time.realtimeSinceStartup;

        while (counter < Amount)
        {
            Instantiate(ObjectRef,Parent);
            counter++;
        }

        endTime = Time.realtimeSinceStartup;

        TimeTaken = endTime - startTime;

        Debug.Log(ObjectRef.name + ": " + TimeTaken);
    }
}
