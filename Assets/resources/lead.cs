using UnityEngine;
using System.Collections;

public class lead : MonoBehaviour {

    public GameObject leader;
    public Rigidbody2D player;
    public float speed, lerpspeed;
    
    private GameObject[] virus;

    


	// Update is called once per frame
	void Update () {
        //gets arrow movement
        key_movement();
        //instantiates an array of all virus objects
        virus = GameObject.FindGameObjectsWithTag("Virus");

    }

    public void FixedUpdate()
    {
        //for each virus move it towards the leader at lerpspeed
        foreach (GameObject obj in virus)
            obj.transform.position = Vector2.MoveTowards(obj.transform.position, leader.transform.position,lerpspeed);
    }


    void key_movement()
    {

        if (Input.GetKey(KeyCode.RightArrow))
            player.AddForce(transform.right * speed);

        if (Input.GetKey(KeyCode.LeftArrow))
            player.AddForce(-transform.right * speed);

        if (Input.GetKey(KeyCode.UpArrow))
            player.AddForce(transform.up * speed);

        if (Input.GetKey(KeyCode.DownArrow))
            player.AddForce(-transform.up * speed);
    }
}
