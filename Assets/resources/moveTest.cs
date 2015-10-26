using UnityEngine;
using System.Collections;


public class moveTest : MonoBehaviour {
    public GameObject virus, healthyCells;
    private GameObject virusHold;
    public Rigidbody2D virus_physics, healthyCells_physics;
    public float speed;
    private Vector3 mousePosition, myForward, myRight;
    private int cellHealth = 100;

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

    void OnCollisionEnter2d(Collision2D col)

    {
        while (col.gameObject.tag == "Healthy Cell" && cellHealth > 0)
            {
            SpriteRenderer cellRenderer = GetComponent<SpriteRenderer>();
            cellRenderer.color = new Color
                (Mathf.SmoothStep(0, 0.5f,Time.time),
                Mathf.SmoothStep(1, 0.5f, Time.time),
                Mathf.SmoothStep(0, 0.5f, Time.time),
                1);
            cellHealth--;
            }
       
    }    



}
