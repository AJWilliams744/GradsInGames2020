using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesMainMenu : MonoBehaviour //TO-DO Merge this class with notes in pause menu
{

    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject allNotesArea;

    [SerializeField] private GameObject selectedNoteArea;
    [SerializeField] private TMP_Text noteTitleArea;
    [SerializeField] private TMP_Text noteContentsArea;

    [SerializeField] private TMP_Dropdown dropDown;

    private void OnEnable()
    {
        ClearMenu();
        OpenNotesMenu();
    }

    public void OpenNotesMenu()
    {
        UpdateDropDown();     
    }

    private void UpdateDropDown()
    {
        dropDown.ClearOptions();


        List<string> allNames = GameSave_Manager.GetAllDimensionNames();

        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        TMP_Dropdown.OptionData baseOption = new TMP_Dropdown.OptionData();
        baseOption.text = "Select Dimension";

        optionList.Add(baseOption);

        foreach (string name in allNames)
        {
            TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData();
            newOption.text = name;

            optionList.Add(newOption);
        }

        dropDown.AddOptions(optionList);

        dropDown.value = 0;
    }

    public void DropDownValueChanged()
    {
        if(dropDown.value == 0) { return; }

        string dimensionName = dropDown.options[dropDown.value].text;

        LoadNotes(dimensionName);
    }

    private void LoadNotes(string dimensionName)
    {
        ClearCurrentNotes();

        DimensionStorage save = GameSave_Manager.LoadDimension(dimensionName);

        foreach (Note nt in save.notes)
        {
            GameObject noteCard;

            noteCard = Instantiate(notePrefab, allNotesArea.transform);
            noteCard.GetComponent<NoteButton>().SetNote(nt, NoteClick);
        }
    }

    private void ClearCurrentNotes()
    {
        foreach (Transform obj in allNotesArea.transform)
        {
            Destroy(obj.gameObject);
        }
    }

    public void NoteClick(Note _note)
    {
        if (_note.Collected)
        {
            noteTitleArea.text = _note.Title;
            noteContentsArea.text = _note.Contents;
        }
        else
        {
            noteTitleArea.text = "Unkown";
            noteContentsArea.text = "Unkown";
        }

    }

    private void ClearMenu()
    {
        foreach (Transform obj in allNotesArea.transform)
        {
            Destroy(obj.gameObject);
        }

        noteTitleArea.text = "";
        noteContentsArea.text = "";
    }
   
}
