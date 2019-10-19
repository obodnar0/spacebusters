using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotator : MonoBehaviour
{
    //public float speed;
    //public float scale = 1;
    public static bool IsPressed = false;
    private static float PrevX;
    private static float PrevY;

    public static void ResetPrev()
    {
        PrevX = Input.mousePosition.x; 
        PrevY = Input.mousePosition.y;
    }


    void Update()
    {
        if (IsPressed)
        {
            transform.Rotate((PrevY - Input.mousePosition.y % 360), -(PrevX - Input.mousePosition.x % 360), 0);
            PrevX = Input.mousePosition.x;
            PrevY = Input.mousePosition.y;
        }
    }
}
