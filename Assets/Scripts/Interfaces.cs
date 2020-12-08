

using System.Collections.Generic;

public interface Interactable
{
    void Interact();
}

public interface Dimension
{
    void PlayerDead();
    void ChoiceSelected(GiftChoices choice);
    void LoadProgress();
    void NextCheckPoint();
    void SwitchTriggered(string name);
    void RemoveGift();
    void NormalStart();
    string GetDimensionName();

    void LinkNotes(List<Note> notes);

    void FoundNote(Note note);
}

public interface PlayerItem // TO-DO finish weapon interface
{
    void MainFire();

    void SecondaryFire();
}
