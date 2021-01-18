using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPick : MonoBehaviour
{
    public raycastWeapon weaponPrefab;
    public GameObject pickUP;
    bool isFPress = false;
    bool isEqip = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFPress = true;
        }
        else
        {

            isFPress = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        
        if (isFPress )
        {
            ActiveWeapon activeWeapon = other.GetComponent<ActiveWeapon>();
            if (activeWeapon)
            {
                raycastWeapon newWeapon = Instantiate(weaponPrefab);
                activeWeapon.Equip(newWeapon);
            }
            Destroy(gameObject);
            isEqip = true;

        }
        if (isEqip)
        {
            pickUP.SetActive(false);

        }

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
