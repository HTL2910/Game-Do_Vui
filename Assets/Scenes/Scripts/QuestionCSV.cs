// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
// using System.IO;
// public class QuestionCSV : MonoBehaviour
// {
    
//     public List<QuestionData> m_questions;
//     public static QuestionCSV Ins;
//     public QuestionData[] questions;
  
//    private void Awake()
//    {
      
//         Ins=this;
//         ReadCSVFile();
//    }
    
    
//     private void Start()
//     {
       
//        gameObject.SetActive(false);
//     }
//     protected void ReadCSVFile()
//     {
//         int index=0;
//         StreamReader strReader = new StreamReader("C:/Users/DELL/Music/DO Vui/Game.csv");
        
//         bool endOfFile = false;
//         while(!endOfFile)
//         {
//             string data_String = strReader.ReadLine();
//             if(data_String==null)
//             {
//                 endOfFile = true;
//                 break;
//             }
//             var data_values = data_String.Split(',');
//             for(int i=0;i<data_values.Length;i=i+5)
//             {
                
//                 questions[index].question=data_values[i];
//                 questions[index].answerA=data_values[i+1];
//                 questions[index].answerB=data_values[i+2];
//                 questions[index].answerC=data_values[i+3];
//                 questions[index].rightAnswer=data_values[i+4];

//                 index++;
//             }
//             m_questions=questions.ToList();
//         } 
//     }
// }