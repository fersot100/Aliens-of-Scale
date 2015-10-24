using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

	// Use this for initialization
	public void begin () {
        Application.LoadLevel("Start");
	}
	
	// Update is called once per frame
	public void game () {
        Application.LoadLevel("Game");
    }

   public void quitGame() {
        Application.Quit();

    }
}
