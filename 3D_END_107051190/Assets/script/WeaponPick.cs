using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPick : MonoBehaviour
{
    public raycastWeapon weaponPrefab;
    public GameObject pickUP;
    public GameObject Player;
    bool isFPress = false;
    bool isEqip = false;
    bool InArea;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InArea)
        {
            ActiveWeapon activeWeapon = Player.GetComponent<ActiveWeapon>();
            if (activeWeapon)
            {
                raycastWeapon newWeapon = Instantiate(weaponPrefab);
                activeWeapon.Equip(newWeapon);
            }
            Destroy(gameObject);
            isEqip = true;
            if (isEqip)
            {
                pickUP.SetActive(false);
            }
        }
        else
        {

            isFPress = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        InArea = true;
       
        

    }
    private void OnTriggerEnter(Collider other)
    {
        pickUP.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        pickUP.SetActive(false);
    }
   

}
