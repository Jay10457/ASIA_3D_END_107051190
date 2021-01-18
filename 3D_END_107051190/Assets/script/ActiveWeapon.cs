using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public Rig handIK;
    public Transform weaponParent;
    raycastWeapon weapon;


    void Start()
    {
        raycastWeapon existingWeapon = GetComponentInChildren<raycastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }
            /*<Call raycastWeapon Rifle>
            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            */

            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }
        }
       
        else
        {
            handIK.weight = 0.0f;
        }
    }
    public void Equip(raycastWeapon newWeapon)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        handIK.weight = 1.0f;
    }
}

