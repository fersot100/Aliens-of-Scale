using UnityEngine;
using System.Collections;


public class moveTest : MonoBehaviour {
    public GameObject virus, healthyCells;
    public Rigidbody2D virus_physics, healthyCells_physics;
    public float speed;
    private Vector3 mousePosition, myForward, myRight;
    public static bool playerIsAlive = true;
    

    Animator player_death;
	public int dieHash = Animator.StringToHash("die");

    // Use this for initialization
    void Start () {
		player_death = GetComponent<Animator>();

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
		AnimatorStateInfo stateinfo = player_death.GetCurrentAnimatorStateInfo(0);
		if(col.gameObject.tag == "tcell")
		{
			player_death.SetTrigger(dieHash);
            Destroy(this.virus, 1.0f);
            Debug.Log("FUCK IM DEAD");
		}
 
    }    

    void Debug_Tools()
    {


    }



}
