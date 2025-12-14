using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int _earnAmount = 10;
    [SerializeField] private float _earnRate = 5f;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _buildingModel;
    [SerializeField] private GameObject _buildingUpgrade;
    [SerializeField] private Transform _buildingLocation;
    [SerializeField] private GameObject _currentBuilding;
    private Player _player;
    private UIManager _uiManager;
    private float _coolDown;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _coolDown = Time.time + _earnRate;
        _player = GameObject.Find("Player").GetComponent<Player>();

        _currentBuilding = Instantiate(_buildingModel, _buildingLocation.position, _buildingLocation.rotation);
        _currentBuilding.transform.parent = this.gameObject.transform;
        Debug.Log("Building spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if(_coolDown< Time.time)
        {
            _coolDown = Time.time + _earnRate;
            _player.Finances(_earnAmount);
            
            Debug.Log("Profit earned!!!");
        }
        _timer = _earnRate - (_coolDown - Time.time);
        _uiManager.SliderValue(_timer);
        
        if(SelectionManager.Instance.SelectedObject == _buildingModel)
        {
            IsSelected(true);
        }
        else
        {
            IsSelected(false);
        }
            
        
    }

    public void IsSelected(bool selected)
    {
        if(selected == true)
        {
            _platform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            _platform.gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }

    public void Upgrade()
    {
        Destroy(_currentBuilding);
        _currentBuilding = Instantiate(_buildingUpgrade, _buildingLocation.position, _buildingLocation.rotation);
    }
}
