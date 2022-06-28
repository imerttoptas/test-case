using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject inputText;
    public void NextLevel(int buildindex)
    {
        if (inputText.GetComponentInChildren<Text>().text!="")
        {
            SceneManager.LoadScene(buildindex);
        }
    }
    public void Restart(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }

}
