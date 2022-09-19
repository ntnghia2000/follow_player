using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region [ Fields ]
    [SerializeField] private EnemyController _enemy;
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _spawnDelayTime;
    #endregion

    #region [ Properties ]
    private SpriteRenderer _enemySprite;
    private EnemyController[] _enemies;
    private int _spawnZone;
    private float _randomXPos;
    private float _randomYPos;
    private Vector3 _spawnPosition;
    #endregion

    #region [ Private Methods ]
    void Start()
    {
        _enemies = new EnemyController[50];
        Invoke("SpawnEnemy", 1f);
    }

    private void SpawnEnemy()
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            _spawnZone = Random.Range(0, 4);
            switch (_spawnZone)
            {
                case 0:
                    _randomXPos = Random.Range(-11f, -10f);
                    _randomYPos = Random.Range(-8f, 8f);
                    break;
                case 1:
                    _randomXPos = Random.Range(-10f, 10f);
                    _randomYPos = Random.Range(-7f, -8f);
                    break;
                case 2:
                    _randomXPos = Random.Range(10f, 11f);
                    _randomYPos = Random.Range(-8f, 8f);
                    break;
                case 3:
                    _randomXPos = Random.Range(-10f, 10f);
                    _randomYPos = Random.Range(7f, 8f);
                    break;
            }

            _spawnPosition = new Vector3(_randomXPos, _randomYPos, 0f);
            _enemies[i] = Instantiate(_enemy, _spawnPosition, Quaternion.identity);
            _enemies[i].GetComponent<EnemyController>().GetEnemy().SetTarget(_player.transform);
            _enemySprite = _enemies[i].GetComponent<SpriteRenderer>();
            _enemySprite.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), 1f);
        }
    }

    private IEnumerator SpawnDelayTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    #endregion
}
