

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

}

public interface PlayerItem // TO-DO finish weapon interface
{
    void MainFire();

    void SecondaryFire();
}
