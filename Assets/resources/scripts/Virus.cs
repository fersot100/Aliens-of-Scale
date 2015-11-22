using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Virus : MonoBehaviour {
    public GameObject virus, healthyCells;
    public Rigidbody2D virus_physics;
    public float speed;
    private Vector3 mousePosition, myForward, myRight;
    public static bool playerIsAlive = true;
    public static Vector3 virusPos;

    public Text virusDisplay;
    public Text sickness;

    Animator player_death;
	public int dieHash = Animator.StringToHash("die");

    public levelManager levelManager;
    private bool CountGot = false;
    private int CellCountHold;

    // Use this for initialization
    void Start () {
		player_death = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
        virusPos = virus.transform.position;
        stdMvmnt();
        Display();
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

    void Display()
    {
        virusDisplay.text = "Virus Count: " + life.VirusNumb;

        int cellCount = GameObject.Find("cells").GetComponent<SpawnCells>().cellCount;

        if(!CountGot)
        {
            CellCountHold = cellCount;
            CountGot = true;
        }

       

        sickness.text = "Healthy Cells: " + cellCount;
        Debug.Log(CellCountHold + "Coutn Hold");

        if(cellCount <= 5)
        {
            levelManager.game("level1");

        }
    }



}
