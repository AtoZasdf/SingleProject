using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stagelock : MonoBehaviour
{
    public int Stage;

    Sprite stageimg;
    [SerializeField]
    Sprite lockimg;

    // Start is called before the first frame update
    void Start()
    {
        stageimg = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(lockimg == null)
        {
            if (PlayerPrefs.GetInt("Stage") >= Stage - 1)
            {
                GetComponent<Image>().enabled = true;
                GetComponentInChildren<Text>().enabled = true;
            }
            else
            {
                GetComponent<Image>().enabled = false;
                GetComponentInChildren<Text>().enabled = false;
            }
        }

        if (PlayerPrefs.GetInt("Stage") >= Stage-1)
        {
            GetComponent<Image>().sprite = stageimg;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Image>().sprite = lockimg;
            GetComponent<Button>().interactable = false;
        }
    }
}
