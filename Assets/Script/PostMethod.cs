using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostMethod : MonoBehaviour {

    public InputField theName;
    public InputField fullName;
    public InputField email;
    public InputField date;
    public Text displayText;
   
    

    private void Start() {
        displayText.text = "Press buttons to interact with web server";
    }

    public void OnClickButton() {
        if (theName.text == string.Empty) {

            displayText.text = "Erro : O campo ''Nome'' é obrigatório";
            theName.GetComponent<Image>().color = new Color32(191,96,96,225);
        }

        else if (fullName.text == string.Empty) {
            displayText.text = "Erro : O campo ''Nome completo'' é obrigatório";
            fullName.GetComponent<Image>().color = new Color32(191, 96, 96, 225);
        }

        else if (email.text == string.Empty) {
            displayText.text = "Erro : O campo ''Email'' é obrigatório";
            email.GetComponent<Image>().color = new Color32(191, 96, 96, 225);

        }

        else if (date.text == string.Empty) {
            displayText.text = "Erro : O campo ''Data de nascimento'' é obrigatório";
            date.GetComponent<Image>().color = new Color32(191, 96, 96, 225);
        }

        else {
            displayText.text = "Enviando informações...";
            StartCoroutine(TestRequest(theName.text, fullName.text, email.text, date.text));
         


        }
    }
    public void Refresh() {
        SceneManager.LoadScene("Main");
    }

    IEnumerator TestRequest(string thename, string fullname, string email, string data) {

        string postUrl = $"https://sweetbonus.com.br/sweet-juice/trainee-test/submit?candidate={thename}&fullname={fullname}&email={email}&birthdate={data}";


        using (UnityWebRequest www = UnityWebRequest.Get(postUrl)) {
            yield return www.SendWebRequest();

            if (!www.isNetworkError && !www.isHttpError) {
                displayText.text = www.downloadHandler.text + "\nObrigado !!!";
                
            }
            else {

                Debug.Log(www.error);
            }
        }
    }






   


}