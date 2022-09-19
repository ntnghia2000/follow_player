using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region [ Fields ]
    [SerializeField] private PlayerController _player;
    #endregion

    #region [ Private Methods ]

    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
    #endregion

}
