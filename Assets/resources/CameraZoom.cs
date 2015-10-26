using UnityEngine;
 using System.Collections;
 
 public class CameraZoom : MonoBehaviour {
     
     public float zoomSpeed = 5;
     public float targetOrtho = 60;
     public float smoothSpeed = 5.0f;
     public float maxOrtho = 160;
     public float minOrtho = 10;
 
     void Start() {
         targetOrtho = Camera.main.orthographicSize;
     }
     
     void Update () {

        float scroll = life.VirusNumb;
         if (scroll == 1) {
            targetOrtho = 40;
            // targetOrtho = Mathf.Clamp (targetOrtho, minOrtho, maxOrtho);
         }
        if (scroll > 2 && scroll < 6)
        {
            targetOrtho = 50;
           // targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        if (scroll > 5 && scroll < 14)
        {
            targetOrtho = 60;
            //targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        if (scroll > 13 && scroll < 18)
        {
            targetOrtho = 70;
           // targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        if (scroll > 17 && scroll < 21)
        {
            targetOrtho = 80;
           // targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        if (scroll > 20)
        {
            targetOrtho = 90;
            //targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }


        Camera.main.orthographicSize = Mathf.MoveTowards 
            (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
     }
 }