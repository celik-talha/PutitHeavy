using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderScript : MonoBehaviour
{
    public Slider sensSlider;
    public GameObject sensTextGo;
    TextMeshProUGUI sensTextMesh;
    public float sens;

    private void Start()
    {
        sensTextMesh = sensTextGo.GetComponent<TextMeshProUGUI>();
        sensSlider.onValueChanged.AddListener((v) =>{
            sensTextMesh.text = v.ToString("0.00");
            sens = v;
            PlayerPrefs.SetFloat("MOUSESENS", sens);
            Debug.Log(sens);
        });
    }
}
