using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _verticalForce = 400f;
    [SerializeField] private NamedColor[] _colors;
    [SerializeField] private ParticleSystem _playerParticles;
    private NamedColor _currentColor;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private float _restartDelay = 1;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(new Vector2(0, _verticalForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().CompareTag(_currentColor.Name)) return;
        if (collision.gameObject.GetComponent<SpriteRenderer>().CompareTag("FinishLine"))
        {
            gameObject.SetActive(false);
            Instantiate(_playerParticles, transform.position, Quaternion.identity);
            Invoke(nameof(LoadNextScene), _restartDelay);
            return;
        }

        if (collision.gameObject.GetComponent<SpriteRenderer>().CompareTag("ColorChanger"))
        {
            ChangeColor();
            Destroy(collision.gameObject);
            return;
        }
        
        gameObject.SetActive(false);
        Instantiate(_playerParticles, transform.position, Quaternion.identity);
        Invoke(nameof(RestartScene), _restartDelay);
    }

    private void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void ChangeColor()
    {
        NamedColor newColor;
        do
        {
            newColor = _colors[Random.Range(0, 4)];
        } while (newColor.Name == _currentColor.Name);

        _currentColor = newColor;
        _spriteRenderer.color = _currentColor.Color;
    }
}