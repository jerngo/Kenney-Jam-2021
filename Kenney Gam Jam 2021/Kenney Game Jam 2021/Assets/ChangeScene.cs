using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    void changeScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void ChangeScenebyID(int index)
    {
        SceneManager.LoadScene(index);
    }
}
