using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dataLoad : MonoBehaviour
{
    public Text mytext;
    public string[] items;
    // Use this for initialization
    IEnumerator Start()
    {
        int data;
        int xx;
        float eth;
        float vel;
        float fe;
        float ett;
        //  mytext.text = "data";
        TextMesh textObject = GameObject.Find("smoketext").GetComponent<TextMesh>();
        textObject.text = "Building 1";
        TextMesh textObject1 = GameObject.Find("smokeinten").GetComponent<TextMesh>();
        textObject.text = "Smoke Intensity";
        TextMesh textObject2 = GameObject.Find("ETH").GetComponent<TextMesh>();
        textObject.text = "ETH";
        TextMesh textObject3 = GameObject.Find("ETT").GetComponent<TextMesh>();
        textObject.text = "ETT";
        while (true)
        {
            yield return new WaitForSeconds(2);
            WWW itemsdata = new WWW("http://quzalmehmood.com/show.php");
            yield return itemsdata;
            string itemsDataString = itemsdata.text;
            print(itemsDataString);
            items = itemsDataString.Split(';');
            //  print(items.Length);
            print(GetDataValue(items[items.Length - 2], "sensorTwo:"));
             data = int.Parse(GetDataValue(items[items.Length - 2], "sensorTwo:"));
            if (data > 100)
            {
                 textObject.text = "Smoke Detected";
            }
            else
            {
                textObject.text = "No Smoke Detected";
            }
            /*   if(data < 400)
               {
                   textObject1.text = "Smoke Intenisty: LOW";
               }else if (data > 400)
               {
                   
               }*/
            

           xx = (data + 29) / 10;
            textObject1.text = "Smoke Inensity:"+xx+" ppm";
            //print(xx);
            
            vel = data - 40;
            fe= Mathf.Pow(vel, 0.625f);
           // print(fe);
            eth =49*fe;
            textObject2.text = "Est Disp Height=" + eth + " m";

          //   (3 / 1700) * vel;
          
            ett = data * (.00106f) *vel;
          //  print("vell"+data);
            textObject3.text = "Est Disp Time=" + ett + " min";
        }
    }
   
  
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);

        //  if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
