using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int _nextScene;


    Monster Monster { get; set; }
    public List<Star> Stars { get; private set; }

    public event Action OnLevelFinished;
    public event Action OnLevelLose;
    public event Action OnLevelWin;

    private void Start()
    {
        Monster = FindObjectOfType<Monster>();
        Monster.OnAteCandy += ManageLevelCompletion;

    }

    private void ManageLevelCompletion()
    {
        Stars = FindObjectsOfType<Star>().ToList();

        if(Stars.Count > 0)
        {
            Debug.Log("Not Completed, restart");
            SceneManager.LoadScene(gameObject.scene.buildIndex);
        }
        else
        {
            Debug.Log("WIN");
            SceneManager.LoadScene(_nextScene);

        }
    }
}
