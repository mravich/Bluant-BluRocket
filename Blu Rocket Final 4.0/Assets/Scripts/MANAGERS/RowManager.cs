using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour {


    // PREMADE ROWS EACH WITH DIFFERENT HOLE
    public GameObject[] premadeRows;

    // PREVIOUS SPAWNED ROW
    public GameObject previousRow;

    // LIST OF POSSIBLE ROWS WHICH CAN BE SPAWNED - shouldn't contain previous row
    public List<GameObject> possibleRows;
	public float interval;

    public GameObject pickedRow;
    private GameObject spawnedRow;
	// Use this for initialization
    
	void Start () {

        // START SPAWNING ROWs
        InvokeRepeating("spawnRow",0.2f, interval);
    }
	
	// Update is called once per frame
	void Update () {
       
		
	}
    void spawnRow() {

      

        // CHECK IF THERE IS PREVIOUS ROW 

        if (previousRow)
        {
            
            possibleRows.Clear();
            // CHECK THE LIST OF POSSIBLE ROWS
           
            for (int i = 0; i < premadeRows.Length; i++)
            {
                
                // CHECK IF PREVIOUS ROW IS SAME AS PREMADE ROW
                if (premadeRows[i].name == previousRow.name) {

                   
                }
                else{

                    // SEND ROW TO POSSIBLE ROW LIST 
                    
                    possibleRows.Add(premadeRows[i]);

                }
            }

            int random2 = Random.Range(0, 3);

            for (int i = 0; i <possibleRows.Count ; i++)
            {
                if (i == random2) {

                    pickedRow = possibleRows[random2];
                    previousRow = pickedRow;
                    spawnedRow =  Instantiate(pickedRow, transform.position, Quaternion.identity);
                    spawnedRow.transform.SetParent(transform);

                }
            }
           
        }
        else {

            // SPAWN ANY OF THE 4 premade rows and set it as previous row
       

            // PICK A ROW ON RANDOM
            int random = Random.Range(0, 4);
            pickedRow = premadeRows[random];

            previousRow = pickedRow;
            spawnedRow = Instantiate(pickedRow, transform.position, Quaternion.identity);
            spawnedRow.transform.SetParent(transform);

        }   



    }


}
