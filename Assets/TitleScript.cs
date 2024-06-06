using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string nextSceneName;

    public GameObject HitKey;

    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer % 100 > 50)
        {
            HitKey.SetActive(false);
        }
        else
        {
            HitKey.SetActive(true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
