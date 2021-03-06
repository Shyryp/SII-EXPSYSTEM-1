﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SII_EXPSYSTEM_1
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialogMKB = new OpenFileDialog();
        List<String> question = new List<String>();
        List<String> cars = new List<String>();
        List<List<double>> probabilitiesPlus = new List<List<double>>();
        List<List<double>> probabilitiesMinus = new List<List<double>>();
        List<double> apriorP = new List<double>();

        List<double> playApriorP = new List<double>();
        int presentQuestion = 0;
        int countQuestions = 0;
        int countHypothesis = 0;

        public Form1()
        {
            InitializeComponent();
            openFileDialogMKB.Filter = "Text files(*.mkb)|*.mkb|All files(*.*)|*.*"; 
        }

        private void enterButton_Click(object sender, EventArgs e) //нажатие по кнопке "ввод"
        {
            var ci = new CultureInfo("en-US"); //для правильного определения вещественных переменных в тексте
            double presentValue = Convert.ToDouble(answerTextBox.Text, ci);//берём число из поля ввода, применяем параметры ci, и сохраняем как вещественное
            if (presentValue >= 0 && presentValue <= 1) //проверяем, попадает ли число в диапазон
            {
                if (presentValue > 0.5) // если вероятность больше 0.5, то делаем первую версию алгоритма
                {
                    yesAnswer(presentValue);
                }
                else if (presentValue < 0.5) // если вероятность меньше 0.5, то делаем вторую версию алгоритма
                {
                    noAnswer(presentValue);
                }
            }
            else { return; }
            presentQuestion++; //переходим к следующему вопросу
            updateWindow(); //обновляем информацию в окне
            
        }

        private void sortingList() //сортируем лист гипотез по вероятностям
        {
            Dictionary<string, double> etre = new Dictionary<string, double>();
            for (int i = 0; i < countHypothesis; i++)
            {
                etre.Add(cars[i],playApriorP[i]);
            }
            foreach (KeyValuePair<string, double> author in etre.OrderByDescending(key => key.Value))
            {
                resultList.Items.Add("("+ author.Value.ToString("F4")+") "+ author.Key);
            }

        }
        private void updateWindow() //обновляем окно
        {
            //очищаем всё в окне перед выводом новой инфы
            textBoxQuestion.Clear();
            listAnswers.Items.Clear();
            resultList.Items.Clear();
            inputQuestionsList.Items.Clear();
            int score = 1;
            for (int i = presentQuestion+1; i < question.Count; i++) // вывод оставшихся вопросов
            {
                inputQuestionsList.Items.Add(score + ". " + question[i]);
                score++;
            }
            sortingList(); // сортируем гипотезы по вероятности
            if (presentQuestion < countQuestions) //вывод следующего по счёту вопроса (если он предыдущий не был последним)
            {
                textBoxQuestion.Text = question[presentQuestion];
            }
            else {
                enterButton.Enabled = false;
                answerTextBox.Enabled = false;
            }
        }

        private void yesAnswer(double answer) // по алгоритму если ответили "да"
        {
            double Pp = 0;
            double Pm = 0;
            double Pap = 0;
            for (int i = 0; i < countHypothesis; i++)
            {
                Pp = probabilitiesPlus[i][presentQuestion]; //P+
                Pm = probabilitiesMinus[i][presentQuestion]; //P-
                Pap = playApriorP[i]; //P априорное

                double PHE = (Pp * Pap) / (Pp * Pap + Pm * (1 - Pap)); //формула P(H|E)
                playApriorP[i] = Pap + ((answer - 0.5) * (PHE - Pap)) / (0.5);
            }
        }
        private void noAnswer(double answer) //по алгоритму если ответили "нет"
        {
            double Pp = 0;
            double Pm = 0;
            double Pap = 0;
            for (int i = 0; i < countHypothesis; i++)
            {
                Pp = probabilitiesPlus[i][presentQuestion];
                Pm = probabilitiesMinus[i][presentQuestion];
                Pap = playApriorP[i];

                double PHnE = ((1 - Pp) * Pap) / ((1 - Pp) * Pap + (1 - Pm) * (1 - Pap)); //формула P(H|!E)
                playApriorP[i] = PHnE + ((answer) * (Pap - PHnE)) / (0.5); 
            }
        }
        private void openFile_Click(object sender, EventArgs e) //открытие файла и разчленение полученной информации по векторам
        {
            if (openFileDialogMKB.ShowDialog() == DialogResult.Cancel)
                return;
            string path = openFileDialogMKB.FileName;
            List<String> carsWithInfo = new List<String>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) //запуск потока чтения файла (не эффективно получилось, ну да ладно)
            {
                string line; //переменная для записи очередной строки
                textBox.Clear(); //очищаем текстбокс с вводной информацией базы знаний
                while ((line = sr.ReadLine()) != "") //выносим вводную инфу в текстбокс до тех пор, пока не встретим пустую строку
                {
                    textBox.AppendText(line + "\r\n");
                    Console.WriteLine(line);
                }
                if ((line = sr.ReadLine()) == "Вопросы:") //если попадётся строка "Вопросы:" приступаем к работе с вопросами
                {
                    Console.WriteLine(line);
                    while ((line = sr.ReadLine()) != "") //заносим вопросы в массив вопросов
                    {
                        question.Add(line);
                    }
                    while ((line = sr.ReadLine()) != null) //заносим гипотезы с данными в массив гипотез
                    {
                        carsWithInfo.Add(line);
                    }
                    foreach (string i in question)
                    {
                        Console.WriteLine(i); //пишем все вопросы в консоль для отладки
                    }

                    for(int sc = 0; sc < carsWithInfo.Count; sc++) //здесь парсим все данные для каждой гипотезы и вопроса, внося информацию в определённые массивы
                    {
                        string[] words = carsWithInfo[sc].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); //разделяем на подстроки по запятой
                        int triger = 0;
                        
                        List<double> bufferListProbabilitiesPlus = new List<double>();
                        List<double> bufferListProbabilitiesMinus = new List<double>();
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (j == 0)
                            {
                                cars.Add(words[j]);
                            }
                            else if (j == 1)
                            {
                                var ci = new CultureInfo("en-US");
                                apriorP.Add(Convert.ToDouble(words[j], ci));
                            }
                            else if (j > 1 && triger == 0)
                            {
                                triger = 1;
                            }
                            else if(j > 1 && triger == 1)
                            {
                                var ci = new CultureInfo("en-US");
                                bufferListProbabilitiesPlus.Add(Convert.ToDouble(words[j], ci));
                                triger = 2;
                            }
                            else if (j > 1 && triger == 2)
                            {
                                var ci = new CultureInfo("en-US");
                                bufferListProbabilitiesMinus.Add(Convert.ToDouble(words[j], ci));
                                triger = 0;
                            }
                        }
                        probabilitiesPlus.Add(bufferListProbabilitiesPlus);
                        probabilitiesMinus.Add(bufferListProbabilitiesMinus);
                        foreach (double k in probabilitiesPlus[sc])
                        {
                            Console.Write(k + " ");
                        }
                        foreach (double k in probabilitiesMinus[sc])
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                    }
                    
                    textBoxQuestion.Clear(); //очищаем всё перед тем, как выводить на экран
                    listAnswers.Items.Clear();
                    resultList.Items.Clear();
                    inputQuestionsList.Items.Clear();
                    int score = 1;
                    foreach (string text in question) //выводим список вопросов в текстбокс вопросов
                    {
                        inputQuestionsList.Items.Add(score + ". "+text);
                        score++;
                    }
                    for(int i = 0; i < cars.Count; i++) //выводим список гипотез
                    {
                        resultList.Items.Add("(" + apriorP[i] + ") " +cars[i]);
                    }
                    playThisKB.Enabled = true; //включаем и выключаем необходимые кнопки
                    stopThisKB.Enabled = false;
                    closeThisFile.Enabled = true;
                }
                else { return; } 
            }
        }

        private void playThisKB_Click(object sender, EventArgs e) //кнопка запуска выбранного файла
        {
            playApriorP = apriorP.GetRange(0, apriorP.Count);
            textBoxQuestion.Clear(); //очищаем всё окно
            listAnswers.Items.Clear();
            resultList.Items.Clear();
            inputQuestionsList.Items.Clear();
            int score = 1;
            for (int i = presentQuestion + 1; i < question.Count; i++) //вывод вопросов в текстбокс
            {
                inputQuestionsList.Items.Add(score + ". " + question[i]);
                score++;
            }
            for (int i = 0; i < cars.Count; i++)
            {
                resultList.Items.Add("(" + apriorP[i] + ") " + cars[i]); //вывод гипотез с их вероятностью
            }
            answerTextBox.Enabled = true;
            enterButton.Enabled = true;
            playThisKB.Enabled = false;
            stopThisKB.Enabled = true;
            presentQuestion = 0;
            textBoxQuestion.Text = question[presentQuestion];
            countQuestions = question.Count();
            countHypothesis = cars.Count();
        }

        private void stopThisKB_Click(object sender, EventArgs e) //кнопка остановки 
        {
            playApriorP = apriorP.GetRange(0, apriorP.Count);
            textBoxQuestion.Clear();
            listAnswers.Items.Clear();
            resultList.Items.Clear();
            inputQuestionsList.Items.Clear();
            int score = 1;
            foreach (string text in question)
            {
                inputQuestionsList.Items.Add(score + ". " + text);
                score++;
            }
            for (int i = 0; i < cars.Count; i++)
            {
                resultList.Items.Add("(" + apriorP[i] + ") " + cars[i]);
            }
            answerTextBox.Enabled = false;
            enterButton.Enabled = false;
            playThisKB.Enabled = true;
            stopThisKB.Enabled = false;
        }

        private void closeThisFile_Click(object sender, EventArgs e) //кнопка закрытия файла
        {
            question.Clear();
            cars.Clear();
            probabilitiesPlus.Clear();
            probabilitiesMinus.Clear();
            apriorP.Clear();
            playApriorP.Clear();
            closeThisFile.Enabled = false;
            playThisKB.Enabled = false;
            stopThisKB.Enabled = false;
            textBox.Clear();
            textBoxQuestion.Clear();
            listAnswers.Items.Clear();
            resultList.Items.Clear();
            inputQuestionsList.Items.Clear();
        }
    }
}
