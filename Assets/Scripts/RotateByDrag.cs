using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RotateByDrag : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    public float anglePerInch;
    public Transform cameraHoder;
    public Transform player;
    public float maxPitch;
    public float minPitch;
    public bool hideCusor;
    public float sensitivity;

    private Vector2 starPos;
    private Vector2 delta;
    private float yaw;
    private float pitch;
    private float currentYaw;
    private float currentPitch;
    private bool isDragging;
    private Quaternion desiredPlayerRotation;
    private Quaternion desiredCameraRotation;
#if UNITY_ANDROID
public void OnPointerDown(PointerEventData eventData)
    {
        starPos = eventData.position;
        isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        delta = eventData.position - starPos;
        UpdateYaw();
        UpdatePitch();
    }
    private void UpdateYaw()
    {
       float deltaYaw = delta.x *anglePerInch/Screen.dpi;
        currentYaw = yaw + deltaYaw;
        desiredPlayerRotation = Quaternion.Euler(0, currentYaw, 0);
    }
    private void UpdatePitch()
    {
        float deltaPitch = -delta.y * anglePerInch / Screen.dpi;
        currentPitch = Mathf.Clamp(pitch +deltaPitch,minPitch,maxPitch);
        desiredCameraRotation = Quaternion.Euler(currentPitch,0,0);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pitch = currentPitch;
        yaw = currentYaw;
        isDragging = false;
    }
    private void Update()
    {
        if (isDragging)
        {
            player.localRotation = Quaternion.Lerp(player.localRotation, desiredPlayerRotation, sensitivity*Time.deltaTime);
            cameraHoder.localRotation = Quaternion.Lerp(cameraHoder.localRotation,desiredCameraRotation, sensitivity*Time.deltaTime);
        }
    }
#endif
}
