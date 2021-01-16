﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float aimDuration = 0.01f;
    public Rig aimLayer;
    Camera cam;
    raycastWeapon weapon;
    


    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<raycastWeapon>();
    }


    private void FixedUpdate()
    {
        float yawCamera = cam.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            aimLayer.weight += Time.deltaTime / aimDuration;
        }
        else
        {
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFiring();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.StopFiring();
        }
    }

}
