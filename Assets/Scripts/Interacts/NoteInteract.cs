using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteract : BaseInteract , Interactable
{
    [SerializeField] private int noteID;
    private Note note;
    public void Interact()
    {
        gameManager.FoundNote(note);
        gameObject.SetActive(false);
    }

    public void SetNote(Note _note)
    {
        note = _note;

        if(_note.Collected == true) { gameObject.SetActive(false); }
    }

    public int GetNoteId()
    {
        return noteID;
    }
 
}
