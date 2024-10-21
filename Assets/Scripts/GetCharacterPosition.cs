using UnityEngine;
public class GetCharacterPosition : MonoBehaviour
{
    public GameObject character;
    public Renderer rendererCharacter;
    public static GetCharacterPosition GetCharacterPositionInstance;

    void Awake()
    {
        if (GetCharacterPositionInstance == null)
        {
            GetCharacterPositionInstance = this;
        }
        rendererCharacter = character.GetComponent<Renderer>();
    }

    void Update()
    {
        GetCharacterCurrentPosition();
    }
    public Vector3 GetCharacterCurrentPosition()
    {
        return rendererCharacter.transform.position;
    }
}
