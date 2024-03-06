using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Animator volume;
    public Animator leaderboard;
    public Animator PlayButton;
    public GameObject HealthBar;
    public CubeSpawner LeftSpawner;
    public CubeSpawner RightSpawner;
    public ShootingController LeftPlayer;
    public ShootingController RightPlayer;
    public GameObject Color1;
    public GameObject Color2;
    public GameObject Color3;
    public Animator plane;
    public Animator SuperButton;
    public Animator score;
    public Animator highScore;
    public void OnClick() {
       /*GameCenter.GetComponent<Animator>().Play("GameCenterReverse");
        Settings.GetComponent<Animator>().Play("SettingsReverse");
        PlayButton.GetComponent<Animator>().Play("PlayReverse");*/
        ScoreManager.Instance.ResetScore();

        HealthBar.GetComponentInParent<Animator>().Play("HealthBarTransition", -1, 0f);
        Color1.GetComponent<Animator>().Play("Color1Transition", -1, 0f);
        Color2.GetComponent<Animator>().Play("Color2Transition", -1, 0f);
        Color3.GetComponent<Animator>().Play("Color3Transition", -1, 0f);
        SuperButton.Play("SuperIn", -1, 0);
        score.Play("ScoreIn");
        highScore.Play("highScoreIn");

        LeftSpawner.StartGame();
        RightSpawner.StartGame();
        LeftPlayer.StartGame();
        RightPlayer.StartGame();

    }

    public void GameOver() {
        /*GameCenter.GetComponent<Animator>().Play("GameCenter");
        Settings.GetComponent<Animator>().Play("Settings");
        PlayButton.GetComponent<Animator>().Play("Play");*/
        HealthBar.GetComponent<Animator>().Play("HealthBarReverse");
        
        Color1.GetComponent<Animator>().Play("Colo1Reverse");
        Color2.GetComponent<Animator>().Play("Color2Reverse");
        Color3.GetComponent<Animator>().Play("Color3Reverse");
        LeftSpawner.CancelInvoke();
        RightSpawner.CancelInvoke();
        LeftPlayer.CancelInvoke();
        RightPlayer.CancelInvoke();
        plane.Play("game-end");
        leaderboard.Play("leaderboard-in");
        volume.Play("volume-in");
        PlayButton.Play("play-in");
        //score.Play("ScoreOut");
        //highScore.Play("highScoreOut");
        SuperButton.Play("SuperOut");
        //plane.Play("PlanePositionReverse");
    }
}
