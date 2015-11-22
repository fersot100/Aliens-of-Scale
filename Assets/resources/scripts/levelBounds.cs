using UnityEngine;
using System.Collections;

public class LevelBounds : MonoBehaviour {
	
	
	
	public GameObject leader;
	
	
	
	
	void OnTriggerEnter2D()
	{
		
		leader.GetComponent<lead>().lerpspeed = 1.4f;
		Debug.Log("Hi Level");
	}
	
	void OnTriggerExit2D()
	{
		
		leader.GetComponent<lead>().lerpspeed = 0;
		Debug.Log("bye Level");
	}
}