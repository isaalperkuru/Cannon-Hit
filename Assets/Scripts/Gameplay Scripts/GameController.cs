﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] block;
    public List<GameObject> levels;

    private GameObject level1;
    private GameObject level2;

    private Vector2 level1Pos;
    private Vector2 level2Pos;

    public int shotCount;
    void Start()
    {
        PlayerPrefs.DeleteKey("Level");

        Physics2D.gravity = new Vector2(0, -17);

        SpawnLevel();
    }

    void Update()
    {
        CheckBlocks();
    }

    void SpawnNewLevel(int numberLevel1, int numberLevel2, int min, int max)
    {
        if(shotCount > 1)
            Camera.main.GetComponent<CameraTransitions>().RotateCameraToFront();
        shotCount = 1;

        level1Pos = new Vector2(3.5f, 1f);
        level2Pos = new Vector2(3.5f, -3.4f);

        level1 = levels[numberLevel1];
        level2 = levels[numberLevel2];

        Instantiate(level1, level1Pos, Quaternion.identity);
        Instantiate(level2, level2Pos, Quaternion.identity);

        SetBlocksCount(min, max);
    }

    void SpawnLevel()
    {
        if(PlayerPrefs.GetInt("Level", 0) == 0)
            SpawnNewLevel(0, 17, 3, 5);
        if (PlayerPrefs.GetInt("Level") == 1)
            SpawnNewLevel(1, 18, 3, 5);
        if (PlayerPrefs.GetInt("Level") == 2)
            SpawnNewLevel(2, 19, 3, 6);
        if (PlayerPrefs.GetInt("Level") == 3)
            SpawnNewLevel(5, 20, 4, 7);
        if (PlayerPrefs.GetInt("Level") == 4)
            SpawnNewLevel(12, 28, 5, 8);
        if (PlayerPrefs.GetInt("Level") == 5)
            SpawnNewLevel(14, 29, 7, 10);
        if (PlayerPrefs.GetInt("Level") == 6)
            SpawnNewLevel(15, 30, 6, 12);
        if (PlayerPrefs.GetInt("Level") == 7)
            SpawnNewLevel(16, 31, 9, 15);
    }

    void SetBlocksCount(int min, int max)
    {
        block = GameObject.FindGameObjectsWithTag("Block");

        for (int i = 0; i < block.Length; i++)
        {
            int count = Random.Range(min, max);
            block[i].GetComponent<Block>().SetStartingCount(count);
        }
    }

    void CheckBlocks()
    {
        block = GameObject.FindGameObjectsWithTag("Block");

        if(block.Length < 1)
        {
            RemoveBalls();
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            SpawnLevel();
        }
    }

    void RemoveBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }
    }
}