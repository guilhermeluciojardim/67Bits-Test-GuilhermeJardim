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
    
    public int powerCount, packCount;

    private GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        powerCount=0;
        packCount=0;
        Pack = packList[0];

    }
    // Update is called once per frame
    public void setPowerCount(){
        if (powerCount<5){
            powerCount+=1;
            packAdd();
        } 
        if (powerCount == 5){
            upgradeButton.interactable=true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    public void packAdd(){
        var newITem = Instantiate(itemPack,Pack.transform.position,itemPack.transform.rotation);
        newITem.transform.parent = this.transform;
        Pack=packList[powerCount];
    }

    public void resetPower(){
        this.gameObject.transform.localScale *=1.1f;
        powerCount=0;
        upgradeButton.interactable=false;
        Cursor.lockState = CursorLockMode.Locked;
        DeletePack();
        Pack=packList[0];

    }
    private void DeletePack(){
 
    items =  GameObject.FindGameObjectsWithTag ("item");
 
     for(var i = 0 ; i < items.Length ; i ++)
         Destroy(items[i]);
 
 }

}
