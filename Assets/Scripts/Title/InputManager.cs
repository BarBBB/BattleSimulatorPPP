using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    public InputField inputField;

    void Start()
    {
        //Debug.Log(this);
        inputField = GetComponent<InputField>();
    }

    //public void InputLogger()
    //{

    //    string inputValue = inputField.text;
    //    Debug.Log(inputValue);
    //}

    public void InitInputField()
    {

        // 値をリセット
        inputField.text = "";
    }

    public void setInputField(string value)
    {
        inputField.text = value;
    }
}