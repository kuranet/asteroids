using UnityEngine;
/// <summary>
/// Class of asteroids that appears at the start of the game
/// </summary>
public class Asteroid : MonoBehaviour
{
    Sprite[] Asteroids = new Sprite[3];
    [SerializeField] Sprite Asteroid1;
    [SerializeField] Sprite Asteroid2;
    [SerializeField] Sprite Asteroid3;

    float colliderRadius;
    float mass = 1; 
    // Start is called before the first frame update
    void Start()
    {        
        Asteroids[0] = Asteroid1;
        Asteroids[1] = Asteroid2;
        Asteroids[2] = Asteroid3;

        GetComponent<SpriteRenderer>().sprite = Asteroids[Random.Range(0,3)];

        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }
    void Update()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move asteroid
        transform.position = position;
    }

    public void Initialize(Direction direction, Vector3 pos)
    {
        transform.position = pos;

        float minSpeed = 0.25f;
        float maxSpeed = 1f;
        float magnitude = Random.Range(minSpeed, maxSpeed);
        float angle = Random.Range(0, Mathf.PI / 6);
        switch (direction)
        {
            case Direction.Up:
                angle += Mathf.PI / 6 + Mathf.PI / 4;
                break;
            case Direction.Down:
                angle += Mathf.PI / 6 + Mathf.PI / 4 + Mathf.PI; 
                break;
            case Direction.Left:
                angle += 2 * Mathf.PI / 3 + Mathf.PI / 4;
                break;
            case Direction.Right:
                angle += 2 * Mathf.PI / 6 + Mathf.PI / 4 + Mathf.PI; 
                break;
        }
        
        Vector2 moveDirection = new Vector2(
             Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude,
            ForceMode2D.Impulse);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
            // Set parameters twice smaller
            transform.localScale /= 2;
            colliderRadius /= 2;
            // If new asteroids will be too small
            if (transform.localScale.x < 0.375 || transform.localScale.y < 0.375)
            {
                Destroy(this.gameObject);
            }
            // Instantinate 2 smaller asteroids
            else
            {
                GameObject aster = Instantiate(this.gameObject);
                aster.GetComponent<Asteroid>().StartMoving();
                aster.transform.parent = gameObject.transform.parent;

                aster = Instantiate(this.gameObject);
                aster.GetComponent<Asteroid>().StartMoving();
                aster.transform.parent = gameObject.transform.parent;
            }
            // Destroy bigger one;
            Destroy(this.gameObject);
            ScoreController.Instance.Score++;
        }
    }
    void StartMoving()
    {
        float minSpeed = 0.25f;
        float maxSpeed = 1f;
        float magnitude = Random.Range(minSpeed, maxSpeed);
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 moveDirection = new Vector2(
             Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
}
