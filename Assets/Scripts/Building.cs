using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int _finances = 0;
    [SerializeField] private int _earnings = 10;
    [SerializeField] private float _earnRate = 5f;
    private UIManager _uiManager;
    private float _coolDown;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _coolDown = Time.time + _earnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(_coolDown< Time.time)
        {
            _coolDown = Time.time + _earnRate;
            _finances += _earnings;
            
            Debug.Log("Profit earned!!!");
        }
        _timer = _earnRate - (_coolDown - Time.time);
        _uiManager.SliderValue(_timer);
        _uiManager.FinancesValue(_finances);
    }
}
