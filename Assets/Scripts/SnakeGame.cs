using UnityEngine;

/**
 * Manages the core gameplay of snake game.
 */
public class SnakeGame : MonoBehaviour
{
    // Visual representation of snake.
    public GameObject Snake;

    // Time in seconds between snake movements.
    public float StepPeriod;

    // Direction in which snakes moves.
    public Vector3Int SnakeDirection;

    // Time passed since last step.
    private float _currentPeriod;

    // Boundaries
    private int _minX;
    private int _maxX;
    private int _minY;
    private int _maxY;

    private void Awake()
    {
        var levelScale = transform.localScale;

        // offset the position so that level matches grid
        // for even scale offset is -0.5 for odd scale there is no offset
        var positionOffset = new Vector3(
            (levelScale.x % 2) / 2f - 0.5f,
            (levelScale.y % 2) / 2f - 0.5f,
            0
        );

        transform.position += positionOffset;
        var levelPosition = transform.position;

        // Level boundaries setup in respect of its position
        _maxX = Mathf.FloorToInt(levelPosition.x + levelScale.x / 2);
        _minX = Mathf.CeilToInt(levelPosition.x + -levelScale.x / 2);

        _maxY = Mathf.FloorToInt(levelPosition.y + levelScale.y / 2);
        _minY = Mathf.CeilToInt(levelPosition.y + -levelScale.y / 2);
    }

    private void Update()
    {
        _currentPeriod += Time.deltaTime;

        UpdateSnakeDirection();
        UpdateSnakePosition();
    }

    private void UpdateSnakeDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SnakeDirection = Vector3Int.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SnakeDirection = Vector3Int.down;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SnakeDirection = Vector3Int.right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SnakeDirection = Vector3Int.left;
        }
    }

    private void UpdateSnakePosition()
    {
        if (_currentPeriod >= StepPeriod)
        {
            var snakeTx = Snake.transform;
            var nextPosition = snakeTx.position + SnakeDirection;

            // Wrap position if out of bounds.
            if (nextPosition.x > _maxX)
            {
                nextPosition.x = _minX;
            }
            else if (nextPosition.x < _minX)
            {
                nextPosition.x = _maxX;
            }

            if (nextPosition.y > _maxY)
            {
                nextPosition.y = _minY;
            }
            else if (nextPosition.y < _minY)
            {
                nextPosition.y = _maxY;
            }

            Snake.transform.position = nextPosition;

            // Step was made, reset the period.
            _currentPeriod = _currentPeriod - StepPeriod;
        }
    }
}
