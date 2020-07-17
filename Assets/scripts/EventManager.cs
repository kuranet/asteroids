using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            gameOver.SetActive(true);
            UI.SetActive(false);
        }
    }
}
