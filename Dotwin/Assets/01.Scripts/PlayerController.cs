using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _cameraCenterTrm;


    [SerializeField] private float _startAngle = 60;
    [SerializeField] private float _rotationSpeed = 10f;
    private float _theta;
    private Transform _circleTrm1;
    private Transform _circleTrm2;

    [SerializeField] private float _distance = 1.5f;

    private bool _isPivotCircle1 = true;
    private bool _isRight = true;

    private void Awake()
    {
        _circleTrm1 = transform.Find("Circle1");
        _circleTrm2 = transform.Find("Circle2");
    }

    private void Update()
    {
        Rotate();
        if (_isPivotCircle1) Circle2Rotate();
        else Circle1Rotate();
        ChangePivot();
        ChangeDirection();
        CameraMove();
    }

    private void CameraMove()
    {
        _cameraCenterTrm.position = new Vector3(0, (_circleTrm1.position.y + _circleTrm2.position.y) / 2, -10);
    }

    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isRight = !_isRight;
        }
    }

    private void ChangePivot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isPivotCircle1 = !_isPivotCircle1;
            _theta -= 180 * Mathf.Deg2Rad;
        }
    }

    private void Rotate()
    {
        if (_isRight) _theta += Time.deltaTime * _rotationSpeed;
        else _theta -= Time.deltaTime * _rotationSpeed;
    }

    private void Circle1Rotate()
    {
        _circleTrm1.position = new Vector3(Mathf.Cos(_theta + _startAngle * Mathf.Deg2Rad), Mathf.Sin(_theta + _startAngle * Mathf.Deg2Rad)) * _distance + _circleTrm2.position;
    }

    private void Circle2Rotate()
    {
        _circleTrm2.position = new Vector3(Mathf.Cos(_theta + _startAngle * Mathf.Deg2Rad), Mathf.Sin(_theta + _startAngle * Mathf.Deg2Rad)) * _distance + _circleTrm1.position;
    }
}
