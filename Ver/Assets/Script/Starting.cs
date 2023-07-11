using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    public void AvvioClick()
    {
        SceneManager.LoadScene(1);
    }
}