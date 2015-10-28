using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject tcell;
    private int patrolDir;
    private float upForce = 5, rightForce = 5, currentx, markPos;
    public float pursuitSpd = 40;
    private Vector3 currentPos, targetPos;
    private bool pursuitMode = false;
    
    

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
        if (pursuitMode == true)
            pursuit();
        else
            patrol();

        Debug.Log("pursuit Mode " + pursuitMode);
        
    }

    void patrol()
    {
     
        int cond = 0;
        patrolDir = Random.Range(1, 5);
        
        do
        {
            currentx = rb.transform.position.x;
            if (patrolDir == 1)
            {
                rb.AddForce(transform.up * upForce);
                rb.AddForce(transform.right * rightForce);
            }

            if (patrolDir == 2)
            {
                rb.AddForce(transform.up * upForce);
                rb.AddForce(-transform.right * rightForce);
            }

            if (patrolDir == 3)
            {
                rb.AddForce(-transform.up * upForce);
                rb.AddForce(-transform.right * rightForce);
            }

            if (patrolDir == 4)
            {
                rb.AddForce(-transform.up * upForce);
                rb.AddForce(transform.right * rightForce);
            }

            cond++;

        } while (cond < 1000);
    }

    void pursuit()
    {
        targetPos = moveTest.virusPos;
        float y = targetPos.y - currentPos.y;
        float x = targetPos.x - currentPos.x;
        float step = pursuitSpd * Time.deltaTime;
        transform.position = 
            Vector3.MoveTowards(transform.position, 
            targetPos, 
            step);

        Debug.Log("x = " + x);
        Debug.Log("y = " + y);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Virus")
        {
            pursuitMode = true;
            targetPos = coll.transform.position;
        }
    }

    void OnTriggerExit2d(Collider2D coll)
    {
        if (coll.gameObject.tag == "Virus")
            pursuitMode = false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Virus")
            pursuitMode = true;
    }
    

     
}
