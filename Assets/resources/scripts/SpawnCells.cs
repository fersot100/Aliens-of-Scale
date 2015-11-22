using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCells : MonoBehaviour {

    public GameObject cell1, cell2, cell3, tcell;
    private GameObject cellHold1, cellHold2, cellHold3, cell_container1, cell_container2,
        cell_container3 ,tc, tc_container;
    
    private List<float> spawnLoc, xy;
    private float xlim, ylim, sizeCells1, sizeCells2, sizeCells3;
    private int cellType, tcType, i=0;

    int count = 4;
    GameObject[] cellArr;
    public int cellCount;



    // Use this for initialization
    void Start () {
        cellHold1 = cell1;
        cellHold2 = cell2;
        cellHold3 = cell3;
        tc = tcell;
        spawn_hc();
        
    }
	
	// Update is called once per frame
	void Update () {
        spawn_tc();
        hcCellNumb();
    }

    void random_spawn()
    {
        xlim =  Random.Range(-400,400);
        ylim = Random.Range(-400, 400);
        
        cellType = Random.Range(1, 31);
        sizeCells1 = Random.Range(5, 10);
        sizeCells2 = Random.Range(15, 20);
        sizeCells3 = Random.Range(25, 30);

    }

    void spawn_hc()
    {
        while (i < 35)
        {
            random_spawn();
            if (cellType < 15)
            {


                cell_container1 = Instantiate(cellHold1,
                    new Vector3(xlim, ylim, 0),
                    Quaternion.identity) as GameObject;
                cell_container1.transform.localScale +=
                    new Vector3(sizeCells1, sizeCells1, 0);
            }
            else if (cellType < 25)
            {
                cell_container2 = Instantiate(cellHold2,
                     new Vector3(xlim, ylim, 0),
                     Quaternion.identity) as GameObject;
                cell_container2.transform.localScale +=
                    new Vector3(sizeCells2, sizeCells2, 0);
            }
            else if(cellType < 30)
            {
                cell_container3 = Instantiate(cellHold3,
               new Vector3(xlim, ylim, 0),
               Quaternion.identity) as GameObject;
                cell_container3.transform.localScale +=
                new Vector3(sizeCells3, sizeCells3, 0);
            }
            i++;
        }
    }
            
      
   void spawn_tc()
    {
        

        while(life.VirusNumb >= count)
        {
            random_spawn();
            tc_container =  Instantiate(tc, new Vector3(xlim, ylim, 0),
                        Quaternion.identity) as GameObject;

            count += 5;

        }


        Debug.Log("next tc: " + count);

    }

    void hcCellNumb()
        {
        cellArr = GameObject.FindGameObjectsWithTag("Healthy Cell");

        cellCount = cellArr.Length;
        Debug.Log(cellCount + "hcCellNumb of hc");
    }
    
 

}
