using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private ReactionController _reactionController;
    [SerializeField] private Sprite[] _spriteVars = new Sprite[4];
    private SpriteRenderer _curSprite;

    // Start is called before the first frame update
    void Start()
    {
        _reactionController.OnTimeCoeffUpEventHandler += _reactionController_OnTimeCoeffUpEventHandler;
        _curSprite = GetComponent<SpriteRenderer>();
        _curSprite.sprite = _spriteVars[Random.Range(0, 3)];

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = _curSprite.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.localScale = scale;
    }

    private void _reactionController_OnTimeCoeffUpEventHandler(object sender, ReactionController.OnTimeCoeffUpEventHandlerEventArgs e)
    {
        _curSprite.sprite = _spriteVars[Random.Range(0, 3)];
    }
}
