using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DEBUGHELPER
{
    static bool DEBUGMODE = true;

    public static void Output(string toOut)
    {
        if(DEBUGMODE)
            Debug.Log(toOut);
    }
}
