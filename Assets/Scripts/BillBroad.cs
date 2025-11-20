using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBroad : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
        LookToWardCamera();

    }
    void Update()
    {
        LookToWardCamera();
    }

    public void LookToWardCamera()
    {
        transform.forward = -camera.transform.forward;
    }
}
