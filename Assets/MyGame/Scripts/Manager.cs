using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private float rangeMin;
    [SerializeField]
    private float rangeMax;
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
        time += Time.deltaTime;

        if (time >= maxTime)
        {
            SceneManager.LoadScene(0);
            tileCounter = 0;
        }

    }
    public void SpawnTile()
    {

        Instantiate(tile, new Vector3(Random.Range(rangeMin, rangeMax), Random.Range(rangeMin, rangeMax), 0), Quaternion.identity);
    }
}
