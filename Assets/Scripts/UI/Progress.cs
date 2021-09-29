using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public RectTransform extraBallInner;

    private GameController gameController;

    private float currentWidth, addWith, totalWidth;

    void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        extraBallInner.sizeDelta = new Vector2(31, 117);
        currentWidth = 31;
        totalWidth = 600;
    }

    void Update()
    {
        if(currentWidth >= totalWidth)
        {
            gameController.ballsCount++;
            gameController.ballsCountText.text = gameController.ballsCount.ToString();
            currentWidth = 31;
        }
        if(currentWidth >= addWith)
        {
            addWith += 5;
            extraBallInner.sizeDelta = new Vector2(addWith, 117);
        }
        else
        {
            addWith = currentWidth;
        }
    }

    public void IncreaseCurrentWidth()
    {
        int addRandom = Random.Range(80, 120);
        currentWidth = addRandom + 31 + currentWidth % 576f;
    }
}
