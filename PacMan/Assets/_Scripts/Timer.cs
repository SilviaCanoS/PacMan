using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float restante = 6;

    private void Update()
    {
        if(restante > 0)
        {
            restante -= Time.deltaTime;
            int tempseg = Mathf.FloorToInt(restante % 60);
            timer.text = string.Format("{00:00}", tempseg);
        }
    }
}
