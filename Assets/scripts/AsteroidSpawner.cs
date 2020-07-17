using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    #region SingleTon
    public static AsteroidSpawner Instance { get; private set; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        Spawn(1);
        Spawn(2);
        Spawn(3);
        Spawn(4);
    }

    public void Spawn(int which)
    {
        float radius = asteroidPrefab.GetComponent<CircleCollider2D>().radius;
        GameObject asteroid = Instantiate<GameObject>(asteroidPrefab);

        switch (which)
        {
            case 1:
                Vector3 asteroid1Direction = new Vector3(ScreenUtils.ScreenRight + radius, 0);
                asteroid.GetComponent<Asteroid>().Initialize(Direction.Left, asteroid1Direction);
                break;
            case 2:
                Vector3 asteroid2Direction = new Vector3(ScreenUtils.ScreenLeft - radius, 0);
                asteroid.GetComponent<Asteroid>().Initialize(Direction.Right, asteroid2Direction);
                break;
            case 3:
                Vector3 asteroid3Direction = new Vector3(0, ScreenUtils.ScreenBottom - radius);
                asteroid.GetComponent<Asteroid>().Initialize(Direction.Up, asteroid3Direction); 
                break;
            case 4:
                Vector3 asteroid4Direction = new Vector3(0, ScreenUtils.ScreenTop + radius);
                asteroid.GetComponent<Asteroid>().Initialize(Direction.Down, asteroid4Direction);                
                break; 
        }
        asteroid.transform.parent = gameObject.transform;
    }
}
