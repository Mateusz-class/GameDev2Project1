using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float MatchTimer = 30;
    public float ObjectSpawnerTimer = 3;
    public GameObject PointPrefab;
    public int Points = 0;
    public TMP_Text ScoreText, TimerText, EndText; 
    public bool MatchOver = false;

    // Update is called once per frame
    void Update()
    {
        if (MatchTimer > 0)
        {
            MatchTimer = Mathf.Clamp(MatchTimer - Time.deltaTime, 0, 30);
            UpdateTimerUI();
            if (MatchTimer <= 0)
            {
                MatchOver = true;
                EndText.gameObject.SetActive(true);
            }
            ObjectSpawnerTimer -= Time.deltaTime;
            if (ObjectSpawnerTimer <= 0)
            {
                //Random spawn is professors example
                Vector3 randomSpawn = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f) ,0);
                Instantiate(PointPrefab, randomSpawn, Quaternion.identity);
                ObjectSpawnerTimer = Mathf.CeilToInt(MatchTimer/10); //Spawn a second faster every 10 seconds
            }
        }
    }
    public void AddPoint()
    {
        Points++;
        UpdateScoreUI();
    }
    public void SubtractPoint()
    {
        Points--;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        ScoreText.text = "Points: " + Points.ToString();
    }
    private void UpdateTimerUI()
    {
        TimerText.text = "Time Left: " + MatchTimer.ToString("N0");
        //Learned how to round the timer from here:
        //https://stackoverflow.com/questions/67160505/how-can-i-remove-decimal-at-timer-on-c-sharp
    }
}
