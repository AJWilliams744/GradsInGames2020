

public interface Interactable
{
    void Interact();
}

public interface Dimension
{
    void PlayerDead();
    void ChoiceSelected(GiftChoices choice);
}

public interface PlayerItem // TO-DO finish weapon interface
{
    void MainFire();

    void SecondaryFire();
}
