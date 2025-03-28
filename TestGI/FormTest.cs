using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{
    public partial class FormTest : Form
    {
        Random rnd = new Random();

        List<Question> listQuestion = new List<Question>();

        int indexQuestion = 0;
        int countRightAnswer = 0;
        string[] diagnose = { "идиот", "кретин", "дурак", "норма", "талант", "гений" };
        int[] orderQuestions = {2, 3, 1, 0, 4}; 

        public FormTest()
        {
            InitializeComponent();
            
            listQuestion.Add(new Question("2 + 2 * 2", 6));
            listQuestion.Add(new Question("бревно", 9));
            listQuestion.Add(new Question("пальцы", 25));
            listQuestion.Add(new Question("свечи", 3));
            listQuestion.Add(new Question("уколы", 60));
            startTest();
        }

        int[] shuffle()
        {
            int[] temp = {0, 1, 2, 3, 4};
            for (int i = 0; i < 10; i++)
            {
                int ind1 = rnd.Next(0, 5);
                int ind2 = rnd.Next(0, 5);
                int t = temp[ind1];
                temp[ind1] = temp[ind2];
                temp[ind2] = t;
            }
            return temp;
        }

        void startTest()
        {
            orderQuestions = shuffle();
            indexQuestion = 0;
            countRightAnswer = 0;
            labelQuestion.Text = listQuestion[orderQuestions[indexQuestion]].ToString();
            labelNumberOfQuestion.Text = "Вопрос №" + (indexQuestion + 1).ToString();
            buttonNewStart.Visible = false;
        }

        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            if (indexQuestion < listQuestion.Count)
            {
                int userAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
                if (listQuestion[orderQuestions[indexQuestion]].checkAnswer(userAnswer));
                    countRightAnswer++;
                indexQuestion++;
                if (indexQuestion < listQuestion.Count)
                {
                    labelQuestion.Text = listQuestion[orderQuestions[indexQuestion]].ToString();
                    labelNumberOfQuestion.Text = "Вопрос №" + (indexQuestion + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show(diagnose[countRightAnswer]);
                buttonNewStart.Visible = true;
            }

        }

        private void buttonNewStart_Click(object sender, EventArgs e)
        {
            startTest();
        }
    }
}
