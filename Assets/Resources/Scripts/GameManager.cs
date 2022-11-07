using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool DEBUGMODE = false;
    enum GamePhase { WaitForSignal, WaitForShooting, WaitForReset }
    enum Player { Cowboy, Cowgirl }

    public GameObject cowboy;
    public GameObject cowgirl;
    public GameObject Signal;
    public Vector2 timeBeforeShoot;
    public Vector2 timeBeforeReset;


    Cowboy cScript;
    public Cowboy cowgirlScript;
    Signal sScript;

    GamePhase gamePhases;

    float timeOfInvoke;
    float timeOfReset;

    void Awake()
    {
        //Caching
        cScript = cowboy.GetComponent<Cowboy>();
        cowgirlScript = cowgirl.GetComponent<Cowboy>();
        sScript = Signal.GetComponent<Signal>();


        //Start Game
        ResetRound();
    }




    // Update is called once per frame
    void Update()
    {
        switch (gamePhases)
        {
            case GamePhase.WaitForSignal:

                DEBUGHELPER.Output("Enter WaitForSignalPhase");

                WaitForSignalUpdate();

                break;

            case GamePhase.WaitForShooting:

                DEBUGHELPER.Output("Enter WaitForShootingPhase");
                WaitForShottingUpdate();

                break;

            case GamePhase.WaitForReset:

                DEBUGHELPER.Output("Enter WaitForResetPhase");
                WaitForResetUpdate();

                break;

            default:

                DEBUGHELPER.Output("You are in no game phases.");
                break;
        }
    }

    public void WaitForSignalUpdate()
    {

        //check for user input
        //if user input, pass it to cowboy
        if (Input.GetKeyDown(KeyCode.A))
        {
            cScript.Shoots();
            cScript.CowboyDies("Cowboy");

            DEBUGHELPER.Output("Cowboy died.");
            ResetTime();
            gamePhases = GamePhase.WaitForReset;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            cowgirlScript.Shoots();
            cowgirlScript.CowboyDies("Cowgirl");
            DEBUGHELPER.Output("Cowgirl died.");
            ResetTime();
            gamePhases = GamePhase.WaitForReset;

        }


        // eventually :
        if (Time.time >= timeOfInvoke)
        {
            SignalReady();
            gamePhases = GamePhase.WaitForShooting;
        }


    }
    public void WaitForShottingUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cScript.Shoots();
            cowgirlScript.CowboyDies("Cowgirl");

            DEBUGHELPER.Output("Cowgirl died.");
            ResetTime();
            gamePhases = GamePhase.WaitForReset;


        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            cowgirlScript.Shoots();
            cScript.CowboyDies("Cowboy");

            DEBUGHELPER.Output("Cowboy died.");
            ResetTime();
            gamePhases = GamePhase.WaitForReset;

        }
    }
    public void WaitForResetUpdate()
    {

        if (Time.time >= timeOfReset)
        {
            ResetRound();
        }
    }

    public void ResetRound()
    {
        DEBUGHELPER.Output("Resetting.");

        //reset cowboy position
        cScript.ResetCowboy();
        cowgirlScript.ResetCowboy();

        //reset signal color
        sScript.SetSignalRed();

        //reset main timer    
        timeOfInvoke = Time.time + Random.Range(timeBeforeShoot.x, timeBeforeShoot.y);

        //change the phase to be equal to wait for signal.
        gamePhases = GamePhase.WaitForSignal;
    }

    private void SignalReady()
    {
        //change signal color to green
        sScript.SetSignalGreen();
    }

    private void CowboyShoots(int playerIndex)
    {
        //depends on the phase
        switch (gamePhases)
        {
            case GamePhase.WaitForSignal:
                break;
            case GamePhase.WaitForShooting:
                break;
            case GamePhase.WaitForReset:
                break;
            default:
                break;
        }
        //if(wait for sign phase cowboy looses)
        //if(wait for shooting pahse : cowboy wins
        //if wait for reset : nothing happens
    }
    private void ResetTime()
    {

        timeOfReset = Time.time + Random.Range(timeBeforeReset.x, timeBeforeReset.y);
    }

    /*
    private void CowboyLoses(int pid)
    {
        GetCowboyByPID(pid).CowboyDies();
    }

    private Cowboy GetCowboyByPID(int pid)
    {

    }

    private Cowboy GetOtherCowboy(int pid)
    {

    }*/

}
