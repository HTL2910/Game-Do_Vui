using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    
    public static QuestionManager Ins;
    public QuestionData[] questions;
    List<QuestionData> m_questions;
    QuestionData m_curQuestion;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public QuestionData CurQuestion{get =>m_curQuestion ;set=>m_curQuestion=value;}
    private void Awake()
    {
        m_questions=questions.ToList();
       
        MakeSingleton();
    }
    public QuestionData GetRandomQuestion()
    {
        if(m_questions!=null && m_questions.Count>0)
        {
            int randIdx=Random.Range(0,m_questions.Count);
            m_curQuestion=m_questions[randIdx];
            m_questions.RemoveAt(randIdx);
            
        }
        return m_curQuestion;
    }
   
     public void MakeSingleton()
    {
        if(Ins==null)
        {
            Ins=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //using System.IO;
    //  public QuestionData ReadCSVFile()
    // {
    //     StreamReader strReader = new StreamReader("C:/Users/DELL/Music/thử đố vui/test.csv");
    //     bool endOfFile = false;
    //     while(!endOfFile)
    //     {
    //         string data_String = strReader.ReadLine();
    //         if(data_String==null)
    //         {
    //             endOfFile = true;
    //             break;
    //         }
    //         var data_values = data_String.Split(',');
          
    //         for(int i=0;i<data_values.Length;i=i+5)
    //         {
    //             aquestion.question=data_values[i];
    //             aquestion.answerA=data_values[i+1];
    //             aquestion.answerB=data_values[i+2];
    //             aquestion.answerC=data_values[i+3];
    //             aquestion.rightAnswer=data_values[i+4];
    //             //questions.Add(aquestion);
    //         }
            
    //     }    
    //    return aquestion;
    // }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
// using System.IO;
// public class QuestionManager : MonoBehaviour
// {
    
//     public static QuestionManager Ins;
   
    
//     QuestionData m_curQuestion;
//     // public QuestionData CurQuestion{get =>m_curQuestion ;set=>m_curQuestion=value;}
//     private void Awake()
//     {
//         Ins=this;
        
       
//     }
//     public QuestionData GetRandomQuestion()
//     {
//         if( QuestionCSV.Ins.m_questions!=null &&  QuestionCSV.Ins.m_questions.Count>0)
//         {
//             int randIdx=Random.Range(0, QuestionCSV.Ins.m_questions.Count);
//             m_curQuestion= QuestionCSV.Ins.m_questions[randIdx];
//             QuestionCSV.Ins.m_questions.RemoveAt(randIdx);
            
//         }
//         return m_curQuestion;
//     }
// }
