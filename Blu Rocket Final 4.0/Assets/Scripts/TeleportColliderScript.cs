using System.Collections;
 using System.Collections.Generic;
using UnityEngine;
 
 public class TeleportColliderScript : MonoBehaviour
 {
 
     float timeLeft = 1000.0f;
    // public  bool canTeleport= true;
     bool leftColliderActive, rightColliderActive;    
     int teleportCount = 0;
     Ship playerShip;
 
 
     // Use this for initialization
     void Start()
     {
       //  Debug.Log("ssssssssssssssssssssss!");
 
     }
 
     // Update is called once per frame
     void Update()
    {
         //   Debug.Log(timeLeft);
         //   Debug.Log(canTeleport);
         /* if (!canTeleport)
          {
              timeLeft -= Time.time;
          //    Debug.Log(timeLeft + " - TimeLeft");
              if (timeLeft <= 0)
              {
               //   Debug.Log("Bonus Count is working !!");
                  canTeleport = true;
                  Debug.Log("canTeleport!" + canTeleport);
                  timeLeft = 500.0f;
              }
         }*/
        
     }
     void OnTriggerEnter(Collider coll)
     {
       //  Debug.Log("1.DETECTED COLLISION" + gameObject.name + " -- CAN TELEPORT: " + canTeleport);
        // Debug.Log("2.COLLIDED: "+ gameObject.name+" WITH  THIS:" + coll.gameObject.name);
         
         leftColliderActive = coll.gameObject.GetComponent<Ship>().leftTeleportActive;
         rightColliderActive = coll.gameObject.GetComponent<Ship>().rightTeleportActive;
 
         if (!leftColliderActive && !rightColliderActive)
         {
            // canTeleport = false;
             if (coll.tag == "Player")
             {
 
             //    Debug.Log("3.PLAYER COLLIDED WITH : " + gameObject.name +" CAN TELEPORT:" + canTeleport  );
                 playerShip = coll.GetComponent<Ship>();
                 if (gameObject.name == "LeftCollider")
                 {
                     playerShip.leftTeleportActive = true;
                 }
                 else if (gameObject.name == "RightCollider")
                 {
                     playerShip.rightTeleportActive = true;
                 }
                // Debug.Log("leftTeleport: " + leftColliderActive + "  ,    rightTeleport: " + rightColliderActive);
                 playerShip.teleportShip();
                 BonusCount();
 
 
                 /*if (canTeleport)
                 {
 
                     Vector3 currentPosition = coll.transform.position;
 
                     float currentx = currentPosition.x;
                     Vector3 newPosition = new Vector3(currentx * -1f, currentPosition.y, currentPosition.z);
                     canTeleport = false;
                     coll.transform.position = newPosition;
                     BonusCount();
 
                     Debug.Log("canTeleport!"+canTeleport);
 
 
                 }*/
             }
 
         }
         
         }
     void OnTriggerExit(Collider coll)
     {
       //  Debug.Log("OVAJ OBJEKT : " + coll.gameObject.name + " JE IZASAO IZ " + gameObject.name);
         if (gameObject.name == "LeftCollider")
         {
             coll.gameObject.GetComponent<Ship>().rightTeleportActive = false;
           //  Debug.Log("vratio right na false");
         }
         else if (gameObject.name == "RightCollider")
         {
             coll.gameObject.GetComponent<Ship>().leftTeleportActive = false;
            // Debug.Log("vratio left na false");
         }
 
     }
 
 
     public void BonusCount()
     {
       //  Debug.Log("started with" + gameObject.name);
         playerShip.BonusFromTeleportCounter();
         //Debug.Log("Teleport Count" + teleportCount);
     }
 
 
 }
