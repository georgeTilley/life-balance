using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject player;

    public GameObject peaceCollectable;
    public GameObject PeaceLevel;
    public GameObject peaceCollectables;

    public GameObject ambitionCollectable;
    public GameObject AmbitionLevel;
    public GameObject ambitionCollectables;   
    
    public GameObject loveColllectable;
    public GameObject LoveLevel;
    public GameObject loveColllectables;

    public TextMeshProUGUI goalText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    

    public int startingPlatformCount = 30;

    private float posAtLastSpawn;
    Vector3 spawnPosition = new Vector3();

    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartGame();
        posAtLastSpawn = player.GetComponent<Rigidbody2D>().position.y;
        SpawnPlatforms();
        LoadLevel(0);
        ScoreManager.instance.StartScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().position.y - posAtLastSpawn >= 30f)
        {
            posAtLastSpawn = player.GetComponent<Rigidbody2D>().position.y;
            SpawnPlatforms();
        }

    }

    public void LoadLevel(int pageNumber)
    {
        if (pageNumber == 0)
        {
            AmbitionLevel.SetActive(true);
            ambitionCollectables.SetActive(true);
            PeaceLevel.SetActive(false);
            peaceCollectables.SetActive(false);
            LoveLevel.SetActive(false);
            loveColllectables.SetActive(false);
            //make ambition visisble
            goalText.SetText("Ambition");
            goalText.color = ambitionCollectable.GetComponent<SpriteRenderer>().material.color;
            leftText.color = ambitionCollectable.GetComponent<SpriteRenderer>().material.color;
            rightText.color = ambitionCollectable.GetComponent<SpriteRenderer>().material.color;
            leftText.SetText("Love");
            rightText.SetText("Peace");
        }
        if (pageNumber == 1)
        {
            AmbitionLevel.SetActive(false);
            ambitionCollectables.SetActive(false);
            PeaceLevel.SetActive(true);
            peaceCollectables.SetActive(true);
            LoveLevel.SetActive(false);
            loveColllectables.SetActive(false);
            //make Peace visible
            goalText.SetText("Peace");
            goalText.color = peaceCollectable.GetComponent<SpriteRenderer>().material.color;
            leftText.color = peaceCollectable.GetComponent<SpriteRenderer>().material.color;
            rightText.color = peaceCollectable.GetComponent<SpriteRenderer>().material.color;
            leftText.SetText("Ambition");
            rightText.SetText("Love");
        }
        if (pageNumber == 2)
        {
            AmbitionLevel.SetActive(false);
            ambitionCollectables.SetActive(false);
            PeaceLevel.SetActive(false);
            peaceCollectables.SetActive(false);
            LoveLevel.SetActive(true);
            loveColllectables.SetActive(true);
            //make Love visible
            goalText.SetText("Love");
            goalText.color = loveColllectable.GetComponent<SpriteRenderer>().material.color;
            leftText.color = loveColllectable.GetComponent<SpriteRenderer>().material.color;
            rightText.color = loveColllectable.GetComponent<SpriteRenderer>().material.color;
            leftText.SetText("Peace");
            rightText.SetText("Ambition");
        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < startingPlatformCount; i++)
        {
            posAtLastSpawn = player.GetComponent<Rigidbody2D>().position.y;
            spawnPosition.y += Random.Range(1f, 2.5f);
            spawnPosition.x = Random.Range(-1.2f, 1.2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            int spawnChance = Random.Range(0, 10);
            if (spawnChance > 5)
            {
                Vector3 cPosition = new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z);
                Instantiate(peaceCollectable, cPosition, Quaternion.identity, peaceCollectables.transform);
            }

            spawnChance = Random.Range(0, 10);
            if (spawnChance > 5)
            {
                Vector3 cPosition = new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z);
                Instantiate(ambitionCollectable, cPosition, Quaternion.identity, ambitionCollectables.transform);
            }           
            spawnChance = Random.Range(0, 10);
            if (spawnChance > 5)
            {
                Vector3 cPosition = new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z);
                Instantiate(loveColllectable, cPosition, Quaternion.identity, loveColllectables.transform);
            }
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }
}
