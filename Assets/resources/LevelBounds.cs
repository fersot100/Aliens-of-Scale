using UnityEngine;
using System.Collections;

public class LevelBounds : MonoBehaviour {


	
	public GameObject leader;
	
	

	void OnTriggerEnter2D()
	{
		leader.GetComponent<lead>().inLevel = true;
	}
	
	void OnTriggerExit2D()
	{
		leader.GetComponent<lead>().inLevel = false;
	}
}
