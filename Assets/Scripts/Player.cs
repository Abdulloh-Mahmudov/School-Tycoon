using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int _finances = 0;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private SelectionManager _sManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private float _xBoundary;
    [SerializeField] private float _xBoundaryNegative;
    [SerializeField] private float _yBoundary;
    [SerializeField] private float _yBoundaryNegative;
    [SerializeField] private float _zBoundary;
    [SerializeField] private float _zBoundaryNegative;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundaries();
        _uiManager.FinancesValue(_finances);
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Building"))
                {
                    SelectionManager.Instance.SelectObject(hit.transform.gameObject);
                }
                else
                {
                    SelectionManager.Instance.SelectObject(null);
                }
            }
        }


    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.R)) 
        {
            transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.T))
        {
            transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime, Space.Self);
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(vertical, 0, -horizontal) * _speed * Time.deltaTime, Space.Self);
    }

    public void Finances(int earnings)
    {
        _finances += earnings;
        
    }

    public void Boundaries()
    {
        if (transform.position.x > _xBoundary)
        {
            transform.position = new Vector3(_xBoundary, transform.position.y,transform.position.z);
        }
        else if (transform.position.x < _xBoundaryNegative)
        {
            transform.position = new Vector3(_xBoundaryNegative, transform.position.y, transform.position.z);
        }

        if (transform.position.y > _yBoundary)
        {
            transform.position = new Vector3(transform.position.x, _yBoundary, transform.position.z);
        }
        else if (transform.position.y < _yBoundaryNegative)
        {
            transform.position = new Vector3(transform.position.x, _yBoundaryNegative, transform.position.z);
        }

        if (transform.position.z > _zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _zBoundary);
        }
        else if (transform.position.z < _zBoundaryNegative)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _zBoundaryNegative);
        }
    }
    }
