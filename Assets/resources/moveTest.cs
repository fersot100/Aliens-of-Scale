using UnityEngine;
using System.Collections;

public class moveTest : MonoBehaviour {
    public GameObject virus;
    private GameObject virusHold;
    public Rigidbody2D virus_physics;
    public float speed;
    public int virusNumb;
    private Vector3 mousePosition, myForward, myRight;
   


    // Use this for initialization
    void Start () {
        virusHold = virus;

    }
	
	// Update is called once per frame
	void Update () {
       // key_movement();
        //virus_containermov();
        mousePosition = Input.mousePosition;
        //mouse_movement();
        stdMvmnt();

    }

    void key_movement()
    {

        if (Input.GetKey(KeyCode.RightArrow))
            virus_physics.AddForce(transform.right * speed);

        if (Input.GetKey(KeyCode.LeftArrow))
            virus_physics.AddForce(-transform.right * speed);

        if (Input.GetKey(KeyCode.UpArrow))
            virus_physics.AddForce(transform.up * speed);

        if (Input.GetKey(KeyCode.DownArrow))
            virus_physics.AddForce(-transform.up * speed);
    }


    void stdMvmnt()
    {
        virus_physics.AddTorque(Random.Range(-10.0F, 10.0F));
    }

}
