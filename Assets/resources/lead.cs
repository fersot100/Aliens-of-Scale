using UnityEngine;
using System.Collections;

public class lead : MonoBehaviour {

    public GameObject leader;
    public Rigidbody2D player;
    public float speed, lerpspeed;
    public Camera main;
    private GameObject[] virus;
    private float lerpHold, vnumber;

	void Start()
	{
		lerpHold = lerpspeed;
	}


    // Update is called once per frame
    void Update() {
        //gets arrow movement
        key_movement();
        //instantiates an array of all virus objects
        
		if(Input.GetKey(KeyCode.Space))
		{
			lerpspeed = lerpHold + 1;
		}else
		{
			lerpspeed = lerpHold;
		}
	}

    public void FixedUpdate()
    {
		
        virus = GameObject.FindGameObjectsWithTag("Virus");
        //for each virus move it towards the leader at lerpspeed
		//lerpspeed = 0.2442f*Mathf.Log(virus.Length)+1.5f ;

		Debug.Log ("the virus length is -------->");

        foreach (GameObject obj in virus)
            obj.transform.position = Vector2.MoveTowards(obj.transform.position,
                leader.transform.position, lerpspeed);
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
        
        
        
		if(Input.touchCount > 0 )
		{
			Vector2 touchPos = Input.touches[0].position;
			
			Vector3 touchPosinWorldSpace = main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, main.nearClipPlane));
			
			Debug.Log(touchPos + "touchPos");
			
			transform.position = Vector3.Lerp(transform.position, touchPosinWorldSpace, 1);
		
		}
		
        
    }
 

}
