﻿using System;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 6f;

    PlayerAgent Player;
    Flock Flock;

    Camera viewCamera;
    Vector3 velocity;

    private Action<Vector3> OnMouseLeftClicked;
    private Action<Vector3> OnMouseRightClicked;

    public Vector3 jump;
    {
        Player = GetComponent<PlayerAgent>();
        Flock = FindAnyObjectByType<Flock>();
        CoverFireGroup coverFireGroup = Flock.gameObject.GetComponent<CoverFireGroup>();
        AidFireGroup aidFireGroup = Flock.gameObject.GetComponent<AidFireGroup>();

        viewCamera = Camera.main;

        // LEFT
        OnMouseLeftClicked += Player.ShootToPosition;
        OnMouseLeftClicked += aidFireGroup.ApplyAidFire;

        // RIGHT
        OnMouseRightClicked += coverFireGroup.NPCShootToPosition;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    {
        int floorLayer = 1 << LayerMask.NameToLayer("Floor");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastInfo;
        Vector3 targetPos = Vector3.zero;
        if (Physics.Raycast(ray, out raycastInfo, Mathf.Infinity, floorLayer))
        {
            Vector3 newPos = raycastInfo.point;
            targetPos = newPos;
            targetPos.y += 0.1f;

            Player.AimAtPosition(targetPos);
        }

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClicked(targetPos);
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightClicked(targetPos);
        }
    }
    
	void FixedUpdate()
    {
        Player.MoveToward(velocity);
    }
}