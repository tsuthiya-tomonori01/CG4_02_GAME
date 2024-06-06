using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject GameClearText;

    public static bool isGameClear = false;
    private void OnTriggerEnter(Collider other)
    {
        GameClearText.SetActive(true);

        isGameClear = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
