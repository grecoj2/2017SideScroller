using UnityEngine;
using System.Collections;

public class TransportingPipe : MonoBehaviour {
    public GameObject _Pipe;
    public GameObject player;
    public Transform currentPoint;
    public int positionSelection;
    public Transform[] position;

    //void Start()
    //{
    //  player = GameObject.Find("Player");
    //}

    //void Update()
    //{
    //public void OnTriggerEnter2D(Collider2D collision)
    // {
    //   Input.GetButtonDown("e");
    // transform.position = new Vector3(10, 10, 0);
    //}
    //}
    void Start()
    {
        currentPoint = position[positionSelection];
    }

    
    void Update()
    {
        if Collider2D(collison).istrigger && GetButtonDown("e")== true;
        player.transform.position = Vector3.MoveTowards(player.transform.position, currentPoint.position, 0);

        if (player.transform.position == currentPoint.position)
        {
            positionSelection++;

            if (positionSelection == player.position)
            {
                positionSelection = 0;
            }

            currentPoint = position[positionSelection];
        }

    }
}


  
