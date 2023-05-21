using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using QuizGenerator.Model;

namespace QuizGenerator.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //składowa interfejsu 
        //zdarzenie wywoływane w chwili zmiany własności o której chcemy powiadomić
        //żeby zaktualizowany został widok


        private string quizTitle = "Quiz Title";

        public string QuizTitle { get { return quizTitle; } set { quizTitle = value; } }

        private string questionTitle = "Question Title";

        public string QuestionTitle { get { return questionTitle; } set { questionTitle = value; } }

        
        //private BindingList<Question.Answer> answers = new BindingList<Question.Answer> {
        //    new Question.Answer(){ is_correct=false, content="odp1" },
        //    new Question.Answer(){ is_correct=false, content="" },
        //    new Question.Answer(){ is_correct=false, content="" },
        //    new Question.Answer(){ is_correct=true, content="odp4" }
        //};

        //public BindingList<Question.Answer> Answers { get { return answers; } set { answers = value; } }
        //TODO: use BindingList like above

        private string answer1content = "Answer 1";
        private string answer2content = "Answer 2";
        private string answer3content = "Answer 3";
        private string answer4content = "Answer 4";

        public string Answer1content { get { return answer1content; } set { answer1content = value; } }
        public string Answer2content { get { return answer2content; } set { answer2content = value; } }
        public string Answer3content { get { return answer3content; } set { answer3content = value; } }
        public string Answer4content { get { return answer4content; } set { answer4content = value; } }

        private bool answer1Is_correct = true;
        private bool answer2Is_correct = false;
        private bool answer3Is_correct = false;
        private bool answer4Is_correct = false;

        public bool Answer1Is_correct { get { return answer1Is_correct; } set { answer1Is_correct = value; } }
        public bool Answer2Is_correct { get { return answer2Is_correct; } set { answer2Is_correct = value; } }
        public bool Answer3Is_correct { get { return answer3Is_correct; } set { answer3Is_correct = value; } }
        public bool Answer4Is_correct { get { return answer4Is_correct; } set { answer4Is_correct = value; } }





        //private Quiz currentQuiz;

        //public Quiz CurrentQuiz { get {
        //        return currentQuiz ?? (currentQuiz = new Quiz()); } set { currentQuiz = value; } } 

        public event PropertyChangedEventHandler PropertyChanged;

        private Model.Lottery lottery = new Model.Lottery();

        //private List<Quiz> quizes;

        //public List<Quiz> Quizes
        //{
        //    get { return quizes ?? (quizes = new List<Quiz>()); }
        //    private set
        //    {
        //        quizes = value;

        //        //zgłoszenie zmiany wartości tej własności
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(quizes)));
        //    }
        //}

        //IMPORTANT!!! ważne jest użycie BindingList (zamiast zwykłego List), który implementuje
        //ICollection, Enumerable, IList, IBindingList, ICancelAddNew, IRaiseItemChangedEvents
        //bez jednego z tych interfejsów ListBox nie jest w stanie zobaczyć zmiany w obiekcie
        private BindingList<Quiz> quizes = new BindingList<Quiz>();

        public BindingList<Quiz> Quizes
        {
            get { return quizes; }
            private set
            {
                quizes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quizes)));
            }
        }
        private string test = "";

        //stara implementacja Test która nie powiadamia o zmianie
        //public string Test { get => test; set => test = value; }
        public string Test { 
            get => test;
            set {
                test = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }



        //polecenie 
        private ICommand buttonAddSaveQuiz_Click;

        public ICommand ButtonAddSaveQuiz_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonAddSaveQuiz_Click ?? (buttonAddSaveQuiz_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) => {
                        Quiz currentQuiz = new Quiz(); 
                        currentQuiz.Title = QuizTitle;
                        Question question = new Question();
                        question.Title = QuestionTitle;
                        //skopiuj elementy z Property BidnigList<Answer> Answers do List<Answer> Question.Answers  
                        //question.Answers.AddRange(Answers.Select(i => new Question.Answer()
                        //{
                        //    is_correct = i.is_correct,
                        //    content = i.content
                        //}));
                        //TODO: loop over like above
                        question.Answers = new List<Question.Answer>
                        {
                            new Question.Answer() { is_correct = Answer1Is_correct, content = Answer1content },
                            new Question.Answer() { is_correct = Answer2Is_correct, content = Answer2content },
                            new Question.Answer() { is_correct = Answer3Is_correct, content = Answer3content },
                            new Question.Answer() { is_correct = Answer4Is_correct, content = Answer4content }
                        };
                        currentQuiz.Questions = new List<Question>();
                        currentQuiz.Questions.Add(question);
                        Quizes.Add(currentQuiz);
                        Test = "zmieniony";
                       
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
            }
        }

    }
}
