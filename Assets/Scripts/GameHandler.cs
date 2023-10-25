using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{

    [SerializeField]
    Movement player;

    private int maxScore;
    private int score;
    GameObject[] collectibleTable;

    public TMP_Text pointText;
    public TMP_Text winText;

    //subskrybcja do AddPointEvent podczas startu sceny
    private void OnEnable()
    {
        CollectPoints.AddPointEvent += PointsReceiver;
    }

    //zliczenie punktów oraz ustawienie UI
    private void Start()
    {
        collectibleTable = GameObject.FindGameObjectsWithTag("Points");
        maxScore = collectibleTable.Length;
        winText.gameObject.SetActive(false);
    }
    
    private void PointsReceiver(GameObject sender, EventArgs e)
    {
        score++;
        Debug.Log("---Received---");
        Debug.Log(score + "/" + maxScore);
        if (score / maxScore >= 1)
        {
            
            winText.gameObject.SetActive(true);
            SceneManager.LoadScene("SecondScene");
        }

    }

    //odsubskrybowanie
    private void OnDisable()
    {
        CollectPoints.AddPointEvent -= PointsReceiver;
    }
}
