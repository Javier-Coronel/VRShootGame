using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeDetector : MonoBehaviour
{
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Vida: "+Mathf.Round(GameLogic.Instance.life);
        if (GameLogic.Instance.life <= 0)
        {
            text.text = "Has perdido,\nreiniciando.";
        }
    }
}
