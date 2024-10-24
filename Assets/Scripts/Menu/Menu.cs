using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] public BlackBoard Data;
    [SerializeField] public TMPro.TextMeshProUGUI mText;
    [SerializeField] public Scene GameScene;
    private int kda = 0;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Data.GetValue<int>(DataKey.KDA) != 0)
        {
            if (kda != Data.GetValue<int>(DataKey.KDA))
            {
                kda = Data.GetValue<int>(DataKey.KDA);
                mText.text = "SCORE : " + kda.ToString();
            }
        }
    }
}
