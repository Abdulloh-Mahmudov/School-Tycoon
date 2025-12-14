using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _sliderBar;
    [SerializeField] Text _finances;
    [SerializeField] Button _upgrade;
    private GameObject _selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _selected = SelectionManager.Instance.SelectedObject;
        _upgrade.onClick.RemoveAllListeners();
        
    }

    public void SliderValue(float percentage)
    {
        _sliderBar.value = percentage;
    }

    public void FinancesValue(int money)
    {
        _finances.text = money.ToString();
        if(money >= 30)
        {
            _upgrade.gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            _upgrade.gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
