﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class life : MonoBehaviour {

	public AsyncOperation asyc;
    public float cellStrength;
    public static float VirusNumb = 0;
    float virusColliding = 0, virusAttack, colortime = 0;
    public GameObject virusPrefab;
    private GameObject virusHold;
    public int colorChoice, virusMin, virusMax;
    private Color colorPick;
    GameObject[] virus;
    float highScore, score = 2;



	// Use this for initialization
	void Start () {
        //for cloning virus after cell dies
        virusHold = virusPrefab;
        //selects color based on cell type
        switch (colorChoice)
        {
            case 1:
                colorPick = new Color(0.5f, 0.6f, 0.5f, 1);
                break;
            case 2:
                colorPick = Color.blue;
                break;
            case 3:
                colorPick = Color.red;
                break;
        }
        //sets cell to selected color
        GetComponent<SpriteRenderer>().color = colorPick;
        
		asyc = Application.LoadLevelAsync("GameOver");
		asyc.allowSceneActivation = false;

    }


	
	// Update is called once per frame
	void Update () {
        //appends all viruses to this array
        virus = GameObject.FindGameObjectsWithTag("Virus");
        VirusNumb = virus.Length;


            

              if(VirusNumb == 0)
                     GameOver();
              if(VirusNumb < 1)
              {
                   GameOver();
              }
       
        score = VirusNumb - 1;

        if (score > highScore) highScore = score;


        //if touching viruses inflict damage to cell based on number of viruses
        cellDamage();


    }





    //adds value to damage amount
    void OnCollisionEnter2D(Collision2D collision)
    { if(collision.transform.gameObject.tag == "Virus")
        {
            virusColliding++;
        }

        if(collision.transform.gameObject.tag == "tcell")
        {
            GameObject virus = GameObject.Find("lead");
            lead movetest = virus.GetComponent<lead>();
            
        }
    }

    //reduces damage amount
    void OnCollisionExit2D()
    {
        virusColliding--;
        
    }
    
    
	public void GameOver(){
		asyc.allowSceneActivation = true; 
	}



    void cellDamage()
    {
        if (virusColliding > 0)
        {
            //log of viruses to determine damage amount
            virusAttack = (Mathf.Log(virusColliding) + 2);
            //slow transition from color to black on cells
            colortime += Time.deltaTime * (virusAttack / cellStrength);
            GetComponent<SpriteRenderer>().color =
                Color.Lerp(colorPick, Color.black, colortime);
        }
        else
        {
            //stops damage if no viruses touching
            virusColliding = 0;
        }
        //kills cells and instantiates new viruses
        if (colortime >= 1)
        {
            for (int i = (Random.Range(virusMin, virusMax)); i > 0; i--)
            {
                Instantiate(virusHold, this.transform.position, Quaternion.identity);

            }

            Destroy(this.gameObject);


        }
    }

}
