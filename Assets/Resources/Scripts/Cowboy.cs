using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    public Rigidbody rb;
    public float forceOfImpact;
    public AudioClip gunShot;
    public AudioClip Scream;
    public AudioClip OpponentLaugh;

    AudioSource makeSound;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        makeSound = gameObject.GetComponent<AudioSource>();
    }
    public void CowboyDies(string name)
    {
        //fall over
        if (name == "Cowgirl")
        {
            makeSound.PlayOneShot(Scream);
            rb.AddForce(new Vector3(forceOfImpact, 0, 0));
            makeSound.PlayOneShot(OpponentLaugh);
        }
        else
        {
            makeSound.PlayOneShot(Scream);
            rb.AddForce(new Vector3(-forceOfImpact, 0, 0));
            makeSound.PlayOneShot(OpponentLaugh);

        }
    }

    public void ResetCowboy()
    {
        //comes back up
        if (rb.gameObject.CompareTag("Cowgirl"))
        {
            DEBUGHELPER.Output("Resetting position of Cowgirl");

            transform.position = new Vector3(3, 1, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (rb.gameObject.CompareTag("Cowboy"))
        {
            DEBUGHELPER.Output("Resetting position of Cowboy");
            transform.position = new Vector3(-3, 1, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }

    public void Shoots()
    {
        makeSound.PlayOneShot(gunShot);
    }
}
