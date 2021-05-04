using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


public class PictureRotator : MonoBehaviour
{
    public Slider rotateSlider;
    
    public float rotMinValue;
    public float rotMaxValue;
    // Start is called before the first frame update
    void Start()
    {

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotMinValue;
        rotateSlider.maxValue = rotMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

        
    }

    void RotateSliderUpdate(float value) 
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, value);
    }
}
