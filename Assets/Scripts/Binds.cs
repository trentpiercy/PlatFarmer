using System.Collections;
using UnityEngine;

public class Binds 
{
    public static bool use() {
        return Input.GetKeyDown(KeyCode.G) || 
        Input.GetKeyDown(KeyCode.X) ||
        Input.GetMouseButtonDown(0);
    }

    public static bool pickupDrop() {
        return Input.GetKeyDown(KeyCode.F) || 
        Input.GetKeyDown(KeyCode.Z) || 
        Input.GetMouseButtonDown(1);
    }
}