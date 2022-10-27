using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartText;
    [SerializeField]
    private Sprite[] _livesSprites;
    private Image _livesImage;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";
        _livesImage = GameObject.Find("Lives Image").transform.GetComponent<Image>();
        _gameOverText.SetActive(false);
        _restartText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int lives)
    {
        _livesImage.sprite = _livesSprites[lives];
        if (lives == 0) GameOverSequence();
    }

    void GameOverSequence()
    {
        StartCoroutine(flashGameOverText());
        _restartText.SetActive(true);
    }

    IEnumerator flashGameOverText()
    {
        while (true)
        {
            _gameOverText.SetActive(!_gameOverText.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
