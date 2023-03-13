using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private Slider hpSlider;

    private Character_Stats myStats;
    private float currentHp;

    [SerializeField] private float fadeDuration;
    [SerializeField] private float fadeTimer;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

        myStats = GetComponentInParent<Character_Stats>();

        myStats.OnHealthChangedCallback += UpdateUI;
        
        currentHp = myStats.GetMaxHP();

        hpSlider.maxValue = myStats.GetMaxHP();
        hpSlider.value = currentHp;
    }

    private void Update()
    {
        if (isOn)
        {
            fadeTimer -= Time.deltaTime;

            if (fadeTimer <= 0)
            {
                ShowElement(false);
            }
        }
    }

    void UpdateUI(float hp)
    {
        fadeTimer = fadeDuration;
        ShowElement(true);
        hpSlider.maxValue = myStats.GetMaxHP();
        hpSlider.value = hp;
    }

    private void ShowElement(bool show)
    {
        if (!show)
        {
            transform.localScale = new Vector3(0, 0, 0);
            isOn = false;
        }
        else
        {
            transform.localScale = new Vector3(.01f,.01f, 1);
            isOn = true;
        }
    }
}
