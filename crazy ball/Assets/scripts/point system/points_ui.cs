using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class points_ui : MonoBehaviour
{
    [SerializeField] TMP_Text points, highScore;
    [SerializeField] GameObject point_display;
    [SerializeField] float tweenTime = 0.5f;
    private void Update()
    {
        // points.text = point_system.instance.point_count.ToString();
        if (points != null && point_display != null)
        {
            if (points.text != point_system.instance.point_count.ToString())
            {
                LeanTween.scale(point_display, new Vector3(3f, 3f, 3f), tweenTime).setEaseOutExpo();
                points.text = point_system.instance.point_count.ToString();
                LeanTween.scale(point_display, new Vector3(1f, 1f, 1f), tweenTime).setEaseOutExpo();

            }
        }
        if (highScore != null)
        {
            highScore.text = "High Score: "+PlayerPrefs.GetFloat("HighScore").ToString();
        }

    }


}
