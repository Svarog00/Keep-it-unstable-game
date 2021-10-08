using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private float _time;
    [SerializeField] private int _initCount;
    [SerializeField] private ReactionController _reactionController;

    private int _count;
    private float _timeCoeff = 1;
    private float _curTime;

    private ObjectPool _objectPool;

    private float _verticalUpBorder;
    private float _verticalDownBorder;
    private float _horizontalRightBorder;
    private float _horizontalLeftBorder;

    private void Start()
    {
        _reactionController.OnNucleeExploded += _reactionController_OnNucleeExploded;
        _reactionController.OnTimeCoeffUpEventHandler += _reactionController_OnTimeCoeffUpEventHandler;

        //Get screen borders
        _verticalUpBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        _verticalDownBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _horizontalRightBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        _horizontalLeftBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;

        _objectPool = GetComponent<ObjectPool>();
        _count = _initCount + 10;
        StartCoroutine(SpawnOnTime());
    }

    private void _reactionController_OnTimeCoeffUpEventHandler(object sender, ReactionController.OnTimeCoeffUpEventHandlerEventArgs e)
    {
        _timeCoeff = e.TimeCoeff;
    }

    private void _reactionController_OnNucleeExploded(object sender, ReactionController.OnNucleeExplodedEventArgs e)
    {
        if(_count < 40)
        {
            _count++;
        }
    }

    private void Update()
    {
        SpawnAdditionalNuclee();
    }

    private void SpawnAdditionalNuclee()
    {
        if(_count > 0 && _curTime <= 0f)
        {
            SpawnNuclee();
            _curTime = _delayTime;
        }
        else
        {
            _curTime -= Time.deltaTime * _timeCoeff;
        }
    }

    private void SpawnNuclee()
    {
        //Spawn random nuclee on the field
        GameObject gameObject = _objectPool.GetFromPool();

        gameObject.GetComponent<IPoolable>().SetPool(_objectPool);
        gameObject.GetComponent<Nuclee>().ReactionController = _reactionController;

        float newX = Random.Range(_horizontalLeftBorder, _horizontalRightBorder);
        float newY = Random.Range(_verticalDownBorder, _verticalUpBorder);
        gameObject.transform.position = new Vector3(newX, newY);
        _count--;
    }

    private IEnumerator SpawnOnTime()
    {
        while(_initCount > 0)
        {
            SpawnNuclee();
            _initCount--;
            yield return new WaitForSeconds(_time);
        }
        _curTime = _delayTime;
    }
}
