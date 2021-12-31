using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityValue : MonoBehaviour
{
    [HideInInspector]
    public float sensitivity;
    public Slider sensitivitySlider;
    public InputField sensitivityInput;
    
    void Start() {
        sensitivity = PlayerPrefs.GetFloat("sensitivity", 100);
        updateSensitivity(sensitivity);
    }

    public void updateSensitivityFromSlider() {
        float sensitivity = sensitivitySlider.value;
        updateSensitivity(sensitivity);
    }

    public void updateSensitivityFromInput() {
        float sensitivity = float.Parse(sensitivityInput.text);
        updateSensitivity(sensitivity);
    }

    public void updateSensitivity(float sensitivity) {
        sensitivitySlider.value = sensitivity;
        sensitivityInput.text = sensitivity.ToString();
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
