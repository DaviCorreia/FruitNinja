using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rig;
    private CircleCollider2D CircleColl;
    public bool isCutting;
    private Camera cam;
    private Vector2 LastPos;
    public float VelocityCut;

    void Start()
    {
        cam = Camera.main;
        rig = GetComponent<Rigidbody2D>();
        CircleColl = GetComponent<CircleCollider2D>();
    }

    void StartCut()
    {
        isCutting = true;
        CircleColl.enabled = true;
        LastPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void StopCut()
    {
        isCutting = false;
        CircleColl.enabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rig.position = newPos;

        float velocity = (newPos - LastPos).magnitude * Time.deltaTime;

        if (velocity > VelocityCut)
        {
            CircleColl.enabled = true;
        }
        else
        {
            CircleColl.enabled = false;
        }
        LastPos = newPos;
    }
}
