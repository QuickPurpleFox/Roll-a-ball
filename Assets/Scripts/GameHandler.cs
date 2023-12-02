using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private int _maxScore;
    private int _score;
    GameObject[] _collectibleTable;

    public TMP_Text pointText;
    public TMP_Text winText;

    public Animator doorsAnimator;

    //subskrybcja do AddPointEvent podczas startu sceny
    private void OnEnable()
    {
        CollectPoints.AddPointEvent += PointsReceiver;
        Boot.ButtonPressedEvent += OpeningDoors;
        _collectibleTable = GameObject.FindGameObjectsWithTag("Points");
    }

    //zliczenie punktów oraz ustawienie UI
    private void Start()
    {
        _maxScore = _collectibleTable.Length;
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
        pointText.text = "Score: 0/" + _maxScore;
    }
    
    private void PointsReceiver(GameObject sender, EventArgs e)
    {
        _score++;
        if (_score / _maxScore >= 1)
        {
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OpeningDoors(GameObject sender, EventArgs e)
    {
        doorsAnimator.SetTrigger("open");
        doorsAnimator.SetTrigger("open");
    }

    //odsubskrybowanie
    private void OnDisable()
    {
        CollectPoints.AddPointEvent -= PointsReceiver;
    }
}
