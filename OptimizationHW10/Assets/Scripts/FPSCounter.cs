using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _fPSText;

    private int _lastFrameIndex;
    private float[] _frameDeltaTimeArray;


    private void Awake()
    {
        _frameDeltaTimeArray = new float[50];
    }

    // Update is called once per frame
    void Update()
    {
        _frameDeltaTimeArray[_lastFrameIndex] = Time.unscaledDeltaTime;
        _lastFrameIndex = (_lastFrameIndex + 1) % _frameDeltaTimeArray.Length;

        _fPSText.text = "FPS: " + Mathf.RoundToInt(CalculateFPS()).ToString();
    }


    private float CalculateFPS()
    {
        float total = 0f;
        foreach (var deltaTime in _frameDeltaTimeArray)
        {
            total += deltaTime;
        }
        return _frameDeltaTimeArray.Length / total;
    }
}
