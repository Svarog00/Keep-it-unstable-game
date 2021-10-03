using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private int _count;
    [SerializeField] ReactionController _reactionController;

    private ObjectPool _objectPool;
    private float _verticalUpBorder;
    private float _verticalDownBorder;
    private float _horizontalRightBorder;
    private float _horizontalLeftBorder;

    private void Start()
    {
        //Get screen borders
        _verticalUpBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        _verticalDownBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _horizontalRightBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        _horizontalLeftBorder = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;

        _objectPool = GetComponent<ObjectPool>();
        StartCoroutine(SpawnOnTime());
    }

    private IEnumerator SpawnOnTime()
    {
        while(true)
        {
            //Spawn random nuclee on the field
            GameObject gameObject = _objectPool.GetFromPool();
            gameObject.GetComponent<IPoolable>().SetPool(_objectPool);
            gameObject.GetComponent<Nuclee>().ReactionController = _reactionController;
            float newX = Random.Range(_horizontalLeftBorder, _horizontalRightBorder);
            float newY = Random.Range(_verticalDownBorder, _verticalUpBorder);
            gameObject.transform.position = new Vector3(newX, newY);
            _count--;

            if (_count == 0)
            {
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(_time);
            }
        }
    }
}
