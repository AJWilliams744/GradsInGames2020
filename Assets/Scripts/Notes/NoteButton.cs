using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NoteButton : MonoBehaviour
{
    private Note note;
    private Button button;

    public delegate void methodPasser(Note note);

    [SerializeField] private TMP_Text tileText;

    public void SetNote(Note _note, methodPasser buttonClick)
    {
        note = _note;

        if (note.Collected)
        {
            tileText.text = note.Title;
        }
        else
        {
            tileText.text = "Unkown";
        }
       

        button.onClick.AddListener(delegate { buttonClick(note); });
    }

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        
    }


}
