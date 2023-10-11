using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class physicsGameManager : MonoBehaviour
{
    public float timer;
    public float spawnTimer;
    public TextMeshProUGUI myTimerText;
    public GameObject myEnemy;
    public int timerBound;
    float waveInterval;
    float waveTimer;

    public TextMeshProUGUI playerScores;

    public GameObject myPlayer;
    carController myCarControllers;

    public Vector2 myXbounds;
    public Vector2 myYbounds;

    public GameObject[] wave1;
    public GameObject[] wave2;
    public GameObject[] wave3;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        spawnTimer = 0f;

        


    }
    void spawnCube(GameObject myCube)
    {
       
        cubeEnergy newScript = myCube.GetComponent<cubeEnergy>();
        newScript.SetPlayer(myPlayer);
    }

    void spawnRamp(GameObject myRamp)
    {
        
        rampEnemy newScript = myRamp.GetComponent<rampEnemy>();
        newScript.SetPlayer(myPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //float timeDisplay = Mathf.RoundToInt(timer);
        //myTimerText.text = timeDisplay.ToString();

        int waveCount = 0;

        spawnTimer += Time.deltaTime;


        //Vector3 targetPos = new Vector3(Random.Range(myXbounds.x, myXbounds.y), Random.Range(myYbounds.x, myYbounds.y), 0);
        if (spawnTimer > 2f)


        if(waveTimer > waveInterval)
            {
                waveCount++;
                int waveLength = 0;

                if (waveCount == 1)
                {
                    waveLength = wave1.Length;
                    SpawnWave(wave1, waveLength);
                }

                else if(waveCount == 2)
                {
                    waveLength = wave2.Length;
                    SpawnWave(wave2, waveLength);
                }

                else if (waveCount == 3)
                {
                    waveLength = wave3.Length;
                    SpawnWave(wave3, waveLength);
                }

                else { waveLength = 0; }

                waveTimer = 0f;
                waveInterval = waveInterval *= 1.2f;
            }
        void SpawnWave(GameObject[]myWave, int waveCount)
        {
            for (int i = 0; i < waveCount; i++)
            {
                Vector3 targetPos = new Vector3 (UnityEngine.Random.Range(myXbounds.x, myXbounds.y),
                                    2f,
                                    UnityEngine.Random.Range(myYbounds.x, myYbounds.y));

                GameObject newEnemy = Instantiate(wave1[i], targetPos, Quaternion.identity);

                if (newEnemy.tag == "ramp") { spawnRamp(newEnemy); }
                else if (newEnemy.tag == "cube") { spawnCube(newEnemy); }
                else { Debug.Log("INVALID enemy type"); }
            }
        }

        /*{
            Instantiate(myEnemy, targetPos, Quaternion.identity);
            GameObject newEnemy = Instantiate(myEnemy, targetPos, Quaternion.identity);
            cubeEnergy newScript = newEnemy.GetComponent<cubeEnergy>();
            newScript.SetPlayer(myPlayer);


            spawnTimer = 0f;
        }*/
    }

        

}
