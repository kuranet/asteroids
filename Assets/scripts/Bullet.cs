using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Force = 8;
    Timer liveTimer;
    void Start()
    {
        liveTimer = gameObject.AddComponent<Timer>();
        liveTimer.Duration = 2;
        liveTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (liveTimer.Finished)
            Destroy(gameObject);
    }
    public void ApplyForce(Vector2 directionForce)
    {
        GetComponent<Rigidbody2D>().AddForce(Force * directionForce,
                    ForceMode2D.Force);
    }
}
