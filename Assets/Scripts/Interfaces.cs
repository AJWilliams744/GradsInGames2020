

public interface Interactable
{
    void Interact();
}

public interface Dimension
{
    void PlayerDead();
    void ChoiceSelected(int choiceNumber);
}

public interface PlayerWeapon // TO-DO finish weapon interface
{
    void Fire();

    float GetFireCooldown();
}
