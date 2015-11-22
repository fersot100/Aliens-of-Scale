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
        float vcount = life.VirusNumb;
         if (vcount == 1) 
            targetOrtho = 50;
         
        if (vcount > 2 && vcount < 6) targetOrtho = 50;



        if (vcount > 5 && vcount < 14) targetOrtho = 60;



        if (vcount > 13 && vcount < 18) targetOrtho = 70;



        if (vcount > 17 && vcount < 21) targetOrtho = 80;



        if (vcount > 20 && vcount < 26) targetOrtho = 90;



        if (vcount > 25) targetOrtho = 110;

        Camera.main.orthographicSize = Mathf.MoveTowards 
            (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
     }
 }