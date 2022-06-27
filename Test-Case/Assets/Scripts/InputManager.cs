using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static int gridsize;

    public void ReadStringInput(string s)
    {
        gridsize = (int)Convert.ToInt32(s);
    }
}
