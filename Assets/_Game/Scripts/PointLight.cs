using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    [SerializeField] private Light lightSource;
    [SerializeField] private float minTime = 0.1f;
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float minIntensity = 0.2f;
    [SerializeField] private float maxIntensity = 2f;

    void Start()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float time = Random.Range(minTime, maxTime); 
            lightSource.enabled = !lightSource.enabled; 
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(time);
        }
    }
}
