using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    SpriteRenderer sr;

    [SerializeField]
    Manager m;

    [SerializeField]
    Sprite standardSprite;

    [SerializeField]
    Sprite collectedSprite;

    [SerializeField]
    float kmh;

    bool carryingTile;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = standardSprite;

    }

   
    private void FixedUpdate()
    {
        // Die Rotation wird über die Rotate Funktion gemanaget
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")* (kmh/4));

        // Die Bewegung nach vorne und hinten wird gemanaget
        rb.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical") * kmh);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Es wird überprüft, mit welchem Objekt kollidiert wurde 
        if(collision.CompareTag("Tile"))
        {
            sr.sprite = collectedSprite;
            Destroy(collision.gameObject);
            carryingTile = true;
        }
        else if (collision.CompareTag("Droppoint") && carryingTile)
        {
            sr.sprite = standardSprite;
            m.SpawnTile();
            Manager.tileCounter++;
            carryingTile = false;

        }
    }
}