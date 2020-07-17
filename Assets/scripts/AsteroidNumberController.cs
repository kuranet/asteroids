using System.Collections.Generic;
using UnityEngine;

public class AsteroidNumberController : MonoBehaviour
{
    [SerializeField] ScoreController score;
    int numberOfAsteroids;

    #region SingleTon
    public static AsteroidNumberController Instance { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfAsteroids = gameObject.transform.childCount;
        if (numberOfAsteroids < score.Score && numberOfAsteroids<12)
        {
            int number = Random.Range(1, 5);
            AsteroidSpawner.Instance.Spawn(number);             
        }
        Debug.LogWarning("Asteroids on scene : " + numberOfAsteroids);
    }
}
