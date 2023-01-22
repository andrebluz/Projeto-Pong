using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball";

    public StateMachine stateMachine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            Debug.Log("Bati na bola");
            CountPoint();
        }
    }

    private void CountPoint()
    {
        //StateMachine.Instance.ResetPosition(); moved to player checkmaxpoints();
        player.AddPoint();
    }
   
}
