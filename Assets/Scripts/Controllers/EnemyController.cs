using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region [ Fields ]
    [SerializeField] private Enemy _enemy;
    #endregion

    #region [ Properties ]
    private Vector2 _forward;
    private Vector2 _right;
    private Vector2 _left;
    private Vector2 _back;

    Ray forwardRay;
    Ray backRay;
    Ray leftRay;
    Ray rightRay;
    #endregion

    #region [ Private Methods ]

    void Update()
    {
        if(_enemy.GetTarget() != null)
        {
            if (Vector2.Distance(transform.position, _enemy.GetTarget().position) > _enemy.GetStopDistance())
            {
                transform.position = Vector2.MoveTowards(transform.position, _enemy.GetTarget().position, _enemy.GetSpeedMove() * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, _enemy.GetTarget().position) < _enemy.GetStopDistance())
            {
                transform.position = Vector2.MoveTowards(transform.position, _enemy.GetTarget().position, _enemy.GetSpeedMove() * Time.deltaTime * -2);
            }
        }
        RaycastCheckUpdate();
    }

    private RaycastHit2D CheckRange(Vector2 direction)
    {
        float directOffset = 0.5f * (direction.x > 0 ? 1 : -1);
        Vector2 startingPos = new Vector2(transform.position.x, transform.position.y);
        return Physics2D.Raycast(startingPos, direction, _enemy.GetRange());
    }

    private void RaycastCheckUpdate() 
    {
        _forward = Vector2.up;
        RaycastHit2D frontHit = new RaycastHit2D();
        frontHit = CheckRange(_forward);
        if (frontHit.collider.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, frontHit.transform.position, _enemy.GetSpeedMove() * Time.deltaTime * -1 * _enemy.GetRange());
        }

        _left = Vector2.left;
        RaycastHit2D leftHit = new RaycastHit2D();
        leftHit = CheckRange(_left);
        if (leftHit.collider.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, leftHit.transform.position, _enemy.GetSpeedMove() * Time.deltaTime * -1 * _enemy.GetRange());
        }

        _right = Vector2.right;
        RaycastHit2D rightHit = new RaycastHit2D();
        rightHit = CheckRange(_right);
        if (rightHit.collider.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, rightHit.transform.position, _enemy.GetSpeedMove() * Time.deltaTime * -1 * _enemy.GetRange());
        }

        _back = Vector2.down;
        RaycastHit2D backHit = new RaycastHit2D();
        backHit = CheckRange(_back);
        if (backHit.collider.tag == "Enemy")
        {
            transform.position = Vector2.MoveTowards(transform.position, backHit.transform.position, _enemy.GetSpeedMove() * Time.deltaTime * -1 * _enemy.GetRange());
        }
    }
    #endregion

    #region [ Public Methods ]
    public Enemy GetEnemy()
    {
        return _enemy;
    }
    #endregion

}
