using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualTagCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "TestObj") return;
    }
}
