using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    float health = 1;
    public Image healthBarFill;
    public float healthBlockIncrease = 0.25f;
    public GameObject parent;
    public Animator healthBarAnimator;
    //int green = 255;
    public Button color1;
    public GameObject color1Bar;
    public Button color2;
    public GameObject color2Bar;
    public Button color3;
    public GameObject color3Bar;
    public TextMeshProUGUI countdown;
    public CubeSpawner leftSpawner;
    public CubeSpawner rightSpawner;
    public Play playButton;
    bool gameOver = false;

    private static Manager _instance;

    public static Manager Instance {
        get {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() {
        healthBarAnimator = parent.GetComponent<Animator>();
    }

    IEnumerator ColorTimer() {
       // countdown.text = "3";
        yield return new WaitForSeconds(.5f);
        //countdown.text = "2";
       // yield return new WaitForSeconds(1);
        //countdown.text = "1";                
       // yield return new WaitForSeconds(1);
       // countdown.text = "";   
        color1.interactable = true;
        color2.interactable = true;
        color3.interactable = true;
    }

    public void SelectColor(int button) {
        color1.interactable = false;
        color2.interactable = false;
        color3.interactable = false;

        
        if(button == 0) {
            color1Bar.SetActive(true);
            color2Bar.SetActive(false);
            color3Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color1.gameObject);
        } else if(button == 1) {
            color1Bar.SetActive(false);
            color2Bar.SetActive(true);
            color3Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color2.gameObject);
        } else {
            color1Bar.SetActive(false);
            color2Bar.SetActive(false);
            color3Bar.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(color3.gameObject);
        }

        StartCoroutine(ColorTimer());
    }

    public void ResetHealth() {
        health = 1;
    }

    public void HealhBlock() {
        UpdateHealth(healthBlockIncrease);
    }

    public float GetHealth() {
        return health;
    }

    public void UpdateHealth(float amount) {
        health += amount;

        if(health > 1) {
            health = 1;
        }
        
        healthBarFill.fillAmount = health;
        //green -= 10;
        healthBarFill.color = new Color(1, health, 0, 1);
        
        if(amount < 0) {
            healthBarAnimator.Play("ShakeHealthBar", -1, 0f);
        }

        if(health <= 0) {
            gameOver = true;
            playButton.GameOver();
            ScoreManager.Instance.UpdateHighScore();
        }
    }

    public bool getGameStatus() {
        return gameOver;
    }
}
