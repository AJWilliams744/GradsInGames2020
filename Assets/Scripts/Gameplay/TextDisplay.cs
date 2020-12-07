using System.Collections;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private LaptopAudioManager laptopAudio;
    [SerializeField] private LaptopLightManager laptopLight;
    public enum State { Initialising, Idle, Busy }

    private TMP_Text _displayText;
    private string _displayString;
    private WaitForSeconds _shortWait;
    private WaitForSeconds _longWait;
    private State _state = State.Initialising;

    private WaitForSeconds textSlowSpeed = new WaitForSeconds(0.05f);
    private WaitForSeconds textFastSpeed = new WaitForSeconds(0.02f);

    public bool IsIdle { get { return _state == State.Idle; } }
    public bool IsBusy { get { return _state != State.Idle; } }

    private void Awake()
    {

        _displayText = gameObject.GetComponent<TMP_Text>();

        _shortWait = textSlowSpeed;
        
        _longWait = new WaitForSeconds(1.0f); //Original 0.8f

        _displayText.text = string.Empty;
        _state = State.Idle;
    }

    private IEnumerator DoShowText(string text)
    {
        laptopLight.SwitchOnLight();
        laptopAudio.StartTyping();

        int currentLetter = 0;
        char[] charArray = text.ToCharArray();

        

        while (currentLetter < charArray.Length)
        {
            if (Input.GetButton("MainFire"))
            {
                _shortWait = textFastSpeed;
            }
            else
            {
                _shortWait = textSlowSpeed;
            }

            _displayText.text += charArray[currentLetter++];
            yield return _shortWait;
        }

        laptopAudio.Stop();

        _displayText.text += "\n";
        _displayString = _displayText.text;
        _state = State.Idle;
    }

    private IEnumerator DoAwaitingInput()
    {
        laptopLight.SwitchOnLight();
        laptopAudio.StartWaiting();

        bool on = true;

        while (enabled)
        {
            _displayText.text = string.Format( "{0}> {1}", _displayString, ( on ? "|" : " " ));
            on = !on;
            yield return _longWait;
        }
        laptopAudio.Stop();
    }

    private IEnumerator DoClearText()
    {
        int currentLetter = 0;
        char[] charArray = _displayText.text.ToCharArray();

        while (currentLetter < charArray.Length)
        {
            if (currentLetter > 0 && charArray[currentLetter - 1] != '\n')
            {
                charArray[currentLetter - 1] = ' ';
            }

            if (charArray[currentLetter] != '\n')
            {
                charArray[currentLetter] = '_';
            }

            _displayText.text = charArray.ArrayToString();
            ++currentLetter;
            yield return null;
        }

        laptopLight.SwitchOffLight();
        _displayString = string.Empty;
        _displayText.text = _displayString;
        _state = State.Idle;
    }

    public void Display(string text)
    {
        if (_state == State.Idle)
        {
            StopAllCoroutines();
            _state = State.Busy;
            StartCoroutine(DoShowText(text));
        }
    }

    public void ShowWaitingForInput()
    {
        if (_state == State.Idle)
        {
            StopAllCoroutines();
            StartCoroutine(DoAwaitingInput());
        }
    }

    public void Clear()
    {
        if (_state == State.Idle)
        {
            StopAllCoroutines();
            _state = State.Busy;
            StartCoroutine(DoClearText());
        }
    }
}
