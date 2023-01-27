using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    public GameObject itemPack;
    private GameObject Pack;
    public List<GameObject> packList; 

     public List<GameObject> itemList; 
    public int powerCount;
    private GameObject[] items;

    private GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        itemList = new List<GameObject>();
        powerCount=0;
        Pack = packList[0];
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    public void setPowerCount(){
        if (powerCount<5){
            powerCount+=1;
            packAdd();
        } 
        else if (powerCount == 5){
            upgradeButton.interactable=true;
            Cursor.lockState = CursorLockMode.None;
        }  
    }

    public void packAdd(){
        var newItem = Instantiate(itemPack,Pack.transform.position,player[0].transform.rotation);
        itemList.Add(newItem);
        
        if (powerCount>1){
            newItem.transform.parent = this.transform;
            newItem.transform.parent = itemList[powerCount-1].transform;           
        }
        else{
            newItem.transform.parent = this.transform;
        }
        Pack.gameObject.SetActive(false);
        if (powerCount!=5){
            Pack=packList[powerCount];
        }
    }

    public void resetPower(){
        this.gameObject.transform.localScale *=1.1f;
        powerCount=0;
        upgradeButton.interactable=false;
        Cursor.lockState = CursorLockMode.Locked;
        itemList = new List<GameObject>();
        DeletePack();
        Pack=packList[0];
        

    }
    private void DeletePack(){
    items =  GameObject.FindGameObjectsWithTag ("item");
     for(var i = 0 ; i < items.Length ; i ++){
         Destroy(items[i]);
         packList[i].SetActive(true);
         }
    
 }

}
