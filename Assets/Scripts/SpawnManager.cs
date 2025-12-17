using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _students;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate = 10f;
    private float _coolDown;
    // Start is called before the first frame update
    void Start()
    {
        _coolDown = Time.time + _spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (_coolDown < Time.time)
        {
            _coolDown = Time.time + _spawnRate;
            int randomLocation = Random.Range(0, _spawnPoints.Length);
            int randomStudent = Random.Range(0, _students.Length);
            GameObject student = Instantiate(_students[randomStudent], _spawnPoints[randomLocation].position, Quaternion.identity);
            student.transform.parent = this.gameObject.transform;
        }
    }
}
