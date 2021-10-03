using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private float _time;
    [SerializeField] private int _count;
    [SerializeField] ReactionController _reactionController;

    private float _curTime;

    private ObjectPool _objectPool;

    private float _verticalUpBorder;
    private float _verticalDownBorder;
    private float _horizontalRightBorder;
    private float _horizontalLeftBorder;

    private void Start()
    {
        _reactionController.OnNucleeExploded += _reactionController_OnNucleeExploded;

        //Get screen borders
        _verticalUpBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        _verticalDownBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _horizontalRightBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        _horizontalLeftBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;

        _objectPool = GetComponent<ObjectPool>();
        StartCoroutine(SpawnOnTime());
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
            _curTime -= Time.fixedDeltaTime;
        }
    }

    private void _reactionController_OnNucleeExploded(object sender, System.EventArgs e)
    {
        if(_count <= 20)
        {
            _count++;
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
        while(_count > 0)
        {
            SpawnNuclee();
            yield return new WaitForSeconds(_time);
        }
    }
}
