using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public AudioSource go;

    MeshRenderer mrSignal;
    Material green;
    Material red;

    // Start is called before the first frame update
    void Awake()
    {
        mrSignal = gameObject.GetComponent<MeshRenderer>();
        green = Resources.Load<Material>("Materials/GreenLight");
        red = Resources.Load<Material>("Materials/RedLight");
    }

    public void SetSignalGreen()
    {
        go.Play();
        mrSignal.material = green;
    }

    public void SetSignalRed()
    {
        mrSignal.material = red;
    }
}
