using UnityEngine;

public class RandomAnimationPlayer : MonoBehaviour
{
    public Animator animator; // Посилання на Animator
    public string[] animationNames; // Масив назв анімацій

    void Update()
    {
        // Перевіряємо натискання кнопки E
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayRandomAnimation();
        }
    }

    void PlayRandomAnimation()
    {
        if (animationNames.Length > 0)
        {
            // Вибираємо випадковий індекс з масиву
            int randomIndex = Random.Range(0, animationNames.Length);

            // Програємо анімацію за назвою
            animator.Play(animationNames[randomIndex]);

            Debug.Log("Програється анімація: " + animationNames[randomIndex]);
        }
        else
        {
            Debug.LogWarning("Масив animationNames порожній!");
        }
    }
}