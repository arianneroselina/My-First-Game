using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle _prefab;
    [SerializeField] float _frequency = .3f, _offset = 3f;
    [SerializeField] Transform _left, _mid, _right;

    float _counter = 0f;
    Player _player;
    Transform _transform;

    private void Awake()
    {
        this._player = FindObjectOfType<Player>();
        this._transform = this._player.transform;
    }

    private void Update()
    {
        this._counter += Time.deltaTime;
        if (this._counter >= this._frequency)
        {
            this._counter = 0;
            if (!this._player.Falling())
                this.Spawn();
        }
    }

    void Spawn()
    {
        int num = Random.Range(1, 3);

        for (int i = 0; i < num; i++)
        {
            Vector3 spawnPosition = this._transform.position;
            spawnPosition.x += this._offset;
            switch (Random.Range(0, 3))
            {
                case 0:
                    spawnPosition.z = this._left.position.z;
                    break;
                case 1:
                    spawnPosition.z = this._mid.position.z;
                    break;
                case 2:
                    spawnPosition.z = this._right.position.z;
                    break;
            }
            Instantiate(this._prefab, spawnPosition, Quaternion.identity);
        }
        this._counter = 0f;
    }
}
