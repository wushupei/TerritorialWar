using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public static MainGame Instance;
    List<Gun> guns;
    float curAngle = 0;
    float targetAngle = 90;
    [SerializeField] Text timerTex;
    [SerializeField] Text win;
    [HideInInspector] public bool over;
    private void Start()
    {
        Instance = this;
        guns = new List<Gun>(FindObjectsOfType<Gun>());
    }
    private void Update()
    {      
        GunsRotate();
        if (over) return;
        ShowTimer();
    }
    void GunsRotate()
    {
        curAngle = Mathf.MoveTowardsAngle(curAngle, targetAngle, Time.deltaTime * 45);
        if (curAngle == targetAngle)
        {
            if (targetAngle == 90)
                targetAngle = 0;
            else
                targetAngle = 90;
        }
        foreach (var item in guns)
        {
            item.transform.localEulerAngles = new Vector3(0, 0, curAngle);
        }
    }
    void ShowTimer()
    {
        float seconds = Time.time % 60;
        float minutes = Time.time / 60;
        float hours = minutes / 60;
        timerTex.text = hours.ToString("00") + minutes.ToString(":00") + seconds.ToString(":00.00");
    }
    public void PlayerOut(Gun gun)
    {
        guns.Remove(gun);
        if (guns.Count > 1)
        {
            foreach (var item in guns)
            {
                item.playerSystem.CreateBall();
            }
        }
        else
            GameOver();
    }
    public void GameOver()
    {
        win.color = guns[0].playerSystem.SystemWin();
        win.enabled = true;
        enabled = false;
        over = true;
    }
    public string GetDeathTimer()
    {
        return timerTex.text;
    }
}
