using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Starter : MonoBehaviour
{
    [SerializeField] private Animator objectAnim;

    private float startCounter;

    [SerializeField] private float randomMin, randomMax;
    [SerializeField] private bool canStart;
    private void Awake()
    {
        objectAnim = GetComponent<Animator>();
    }

    void Start()
    {
        canStart = false;
        objectAnim.enabled = false;
        startCounter = Random.Range(randomMin, randomMax);
    }

    void Update()
    {
        if (startCounter>0 && !canStart)
        {
            startCounter -= 1 * Time.deltaTime;
            if (startCounter<=0)
            {
                canStart = true;
                if (canStart)
                {
                    objectAnim.enabled = true;
                }
            }
        }
    }
}
