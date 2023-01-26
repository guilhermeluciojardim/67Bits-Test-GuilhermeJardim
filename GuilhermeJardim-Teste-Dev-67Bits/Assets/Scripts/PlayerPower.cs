using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private Scrollbar powerBar;
    [SerializeField] private Button upgradeButton;
    
    public int powerCount;

    // Start is called before the first frame update
    void Start()
    {
        powerCount=0;
    }
    // Update is called once per frame
    public void setPowerCount(){
        if (powerCount<5){
            powerCount+=1;
            powerBar.value += 0.2f;
        } 
        if (powerBar.value == 1f){
            upgradeButton.interactable=true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void resetPower(){
        this.gameObject.transform.localScale *=1.1f;
        powerCount=0;
        powerBar.value=0f;
        upgradeButton.interactable=false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
