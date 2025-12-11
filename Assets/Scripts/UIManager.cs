using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _sliderBar;
    [SerializeField] Text _finances;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderValue(float percentage)
    {
        _sliderBar.value = percentage;
    }

    public void FinancesValue(int money)
    {
        _finances.text = money.ToString();
    }
}
