using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteract : BaseInteract , Interactable
{
    [SerializeField] private GameObject zoneParent;
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

    public override void Start()
    {
        base.Start();

        if(zoneParent == null) { return; }
        transform.SetParent(zoneParent.transform);
    }

}
