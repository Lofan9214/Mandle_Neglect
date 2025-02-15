using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
/*
 * 버튼을 눌렀을때 인풋필드를 활성화

버튼의 텍스트를 인풋필드의 텍스트로 옮김
 */
public class DataCell : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public TMP_InputField inputField;

    public string CellText => buttonText.text;

    public void Init(string str)
    {
        buttonText.text = str;
    }
    public void ActiveInputFiled()
    {
        inputField.gameObject.SetActive(true);
        inputField.text = CellText;
    }

    public void InputEnd()
    {
        buttonText.text = inputField.text;
        inputField.gameObject.SetActive(false);
    }

    
   

}
