using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAction : MonoBehaviour
{
    public GameObject panel;

    public void buttonMethode()
    {
        Debug.Log("Done !");
    }

    public void Openpanel()
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }

}
