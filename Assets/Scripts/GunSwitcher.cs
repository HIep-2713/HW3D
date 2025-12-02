using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    private int currentIndex;
    public GameObject[] guns; 
    
    // Update is called once per frame
    public void SwitchGun()
    {
        currentIndex = ( currentIndex + 1 ) % guns.Length;
        SetActiveGun(currentIndex);
    }
    void SetActiveGun(int gunIndex)
    {
        for(int i = 0;i < guns.Length;i++)
        {
            bool isAcrice = (i == gunIndex); 
            guns[i].SetActive(isAcrice);
            if (isAcrice)
            {
                guns[i].SendMessage("OnGunSelected",SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
