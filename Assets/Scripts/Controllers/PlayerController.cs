using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region [ Fields ]
    [SerializeField] private float _speed;
    #endregion

    #region [ Properties ]
    private bool _isMove;
    private bool _isEnemyTouched;
    #endregion

    #region [ Private Methods]
    void Start()
    {
        _isMove = false;
        _isEnemyTouched = false;
    }

    void Update()
    {
        ButtonController();
    }

    private void ButtonController()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    }
    #endregion
}
