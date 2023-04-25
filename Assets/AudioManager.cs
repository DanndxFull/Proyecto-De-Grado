using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {        
        audioSource.volume = slider.value;
    }
}
