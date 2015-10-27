using UnityEngine;
using System.Collections;


public class moveTest : MonoBehaviour {
    public GameObject virus, healthyCells;
    private GameObject virusHold;
    public Rigidbody2D virus_physics, healthyCells_physics;
    public float speed;
    private Vector3 mousePosition, myForward, myRight;
 

    // Use this for initialization
    void Start () {
        virusHold = virus;

    }
	
	// Update is called once per frame
	void Update () {
        
        //virus_containermov();
        stdMvmnt();

    }

    void stdMvmnt()
    {
        virus_physics.AddTorque(Random.Range(-10.0F, 10.0F));
    }

    void OnCollisionEnter2D(Collision2D col)

    {

		if(col.gameObject.tag == "tcell")
		{
			Destroy(virus);
			Debug.Log("FUCK IM DEAD");
		}

       
    }    



}
