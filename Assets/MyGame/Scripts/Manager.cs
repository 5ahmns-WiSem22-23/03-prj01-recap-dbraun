using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private float minRange;

    [SerializeField]
    private float maxRange;

    [SerializeField]
    private GameObject tile;

    [SerializeField]
    Text tileCountText;

    public static int tileCounter;

    float time;

    [SerializeField]
    float maxTime;


    [SerializeField]
    Text timeText;



    void Start()
    {
        SpawnTile();
    }

    private void Update()
    {
        tileCountText.text = tileCounter.ToString();
        timeText.text = "Zeit: " + Mathf.Round(maxTime - time).ToString();

        // Timer erstellen/einstellen
        time += Time.deltaTime;

        //Nach Ablauf der Zeit wird das Spiel neu gestartet
        if (time >= maxTime)
        {
            SceneManager.LoadScene(0);
            tileCounter = 0;
        }

        


    }


    public void SpawnTile()
    {
        // Der Bereich des gespawnten Objekts wird zufällig auserwählt
        Instantiate(tile, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
