using System;
using CameraMovement;
using Drags;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Slider : MonoBehaviour
    {
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private SlingShot slingShot;
        [SerializeField] private Drag drag;
        [SerializeField] private Cube cube;
        [SerializeField] private GameObject slider;

        [SerializeField] private TextMeshProUGUI[] texts;

        private void Start()
        {
          
            
            var value1   = PlayerPrefs.GetFloat("ZoomOut" );
            var value2 = PlayerPrefs.GetFloat("Camera" );
            var value3 = PlayerPrefs.GetFloat("Force");
            var value4 = PlayerPrefs.GetFloat("Radius");
            var value5  = PlayerPrefs.GetFloat("Speed" );

            texts[0].text = value1.ToString();
            texts[1].text = value2.ToString();
            texts[2].text = value3.ToString();
            texts[3].text = value4.ToString();
            texts[4].text = value5.ToString();
            
            cameraMover.ZoomOffset = value1;
            cameraMover.Offset = value2;
            slingShot.Force = value3;
            drag.LimitRadius = value4;
            cube.AllowedSpeed = value5;
        }

        public void OnZoomOutValueChange(float value)
        {
            cameraMover.ZoomOffset = value ;
            texts[0].text = value.ToString();
            PlayerPrefs.SetFloat("ZoomOut", value);
            Debug.Log(value);
        }
        public void OnCameraValueChange(float value)
        {
            cameraMover.Offset = value ;
            texts[1].text = value.ToString();
            PlayerPrefs.SetFloat("Camera", value);
            Debug.Log(value);
        }
        public void OnForceValueChange(float value)
        {
            slingShot.Force = value ;
            texts[2].text = value.ToString();
            PlayerPrefs.SetFloat("Force", value);
            Debug.Log(value);
        }
        public void OnRadiusValueChange(float value)
        {
            drag.LimitRadius = value ;
            texts[3].text = value.ToString();
            PlayerPrefs.SetFloat("Radius", value);
            Debug.Log(value);
        }
        public void OnSpeedValueChange(float value)
        {
            cube.AllowedSpeed = value ;
            texts[4].text = value.ToString();
            PlayerPrefs.SetFloat("Speed", value);
            Debug.Log(value);
        }

        public void OnButtonClick()
        {
            slider.SetActive(!slider.activeInHierarchy);
        }
    
    }
}
