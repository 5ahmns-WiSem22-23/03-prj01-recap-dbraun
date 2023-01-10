using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteR;
    Rigidbody2D rigidB;

    [SerializeField]
    Manager m;

    [SerializeField]
    Sprite standardSprite;

    [SerializeField]
    Sprite collectedSprite;

    [SerializeField]
    float speed;

    bool carryingTile;

    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        spriteR.sprite = standardSprite;

    }

   
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")* (speed/4));

        rigidB.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical") * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            spriteR.sprite = collectedSprite;
            Destroy(collision.gameObject);
            carryingTile = true;
        }
        else if (collision.CompareTag("Droppoint") && carryingTile)
        {
            spriteR.sprite = standardSprite;
            m.SpawnTile();
            Manager.tileCounter++;
            carryingTile = false;

        }
    }
}