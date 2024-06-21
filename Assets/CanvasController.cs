using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public static CanvasController instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Slider spacing, maxY, minY, height, width;
    [SerializeField] private TMP_Text spacingText, maxYtText, minYtText, heightText, widthText;
    
    public GameManager gm;
    void Start()
    {
        gm= GameManager.instance;
    }
    void Update()
    {
        gm.spacing = spacing.value;
        gm.maxHeight = maxY.value;
        gm.minHeight = minY.value;
        gm.height = (int) height.value;
        gm.width = (int) width.value;
        
        spacingText.text = spacing.value.ToString("F1");
        maxYtText.text = maxY.value.ToString("F1");
        minYtText.text = minY.value.ToString("F1");
        heightText.text = height.value.ToString("F1");
        widthText.text = width.value.ToString("F1");
    }

    public void GenerateLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void ResetValues()
    {
        spacing.value = 1.15f;
        maxY.value = 0.5f;
        minY.value = 0f;
        height.value = 15;
        width.value = 15;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
