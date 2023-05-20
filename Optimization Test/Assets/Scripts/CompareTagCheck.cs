using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareTagCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("TestObj")) return;
    }
}
