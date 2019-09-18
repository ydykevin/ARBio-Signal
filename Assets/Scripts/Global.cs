using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global 
{
    public static float pointerY = 0.0373f;
    public static float pointerZ = -0.398f;
    public static Vector3 pointerMin = new Vector3( -0.737f, pointerY,pointerZ);
    public static Vector3 pointerMax = new Vector3(0.266f, pointerY, pointerZ);
    public static Vector3 pointerB1 = new Vector3(-0.44f, pointerY, pointerZ);
    public static Vector3 pointerB2 = new Vector3(-0.034f, pointerY, pointerZ);
    public static Vector3 pointerDefault = new Vector3(-0.245f, pointerY, pointerZ);
    public static float sizeModifier = 1f;
    public static int HR = 60;
    public static float SCR = 0.5f;
    public static float scrMax = 0.5f;
}
