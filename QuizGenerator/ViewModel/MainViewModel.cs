using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using QuizGenerator.Model;

namespace QuizGenerator.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //składowa interfejsu 
        //zdarzenie wywoływane w chwili zmiany własności o której chcemy powiadomić
        //żeby zaktualizowany został widok

        private bool isQuizSelected = false;

        public bool IsQuizSelected
        {
            get { return isQuizSelected; }
            set
            {
                isQuizSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsQuizSelected)));
            }
        }

        bool is_both_quiz_and_question_selected = false;

        public bool Is_both_quiz_and_question_selected
        {
            get { return is_both_quiz_and_question_selected; }
            set
            {
                is_both_quiz_and_question_selected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Is_both_quiz_and_question_selected)));
            }
        }

        private bool isQuestionSelected = false;

        public bool IsQuestionSelected
        {
            get { return isQuestionSelected; }
            set
            {
                isQuestionSelected = value;
                if(isQuestionSelected == true && isQuizSelected == true) {
                    Is_both_quiz_and_question_selected = true;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsQuestionSelected)));
            }
        }

        private string quizTitle = "Quiz Title";

        public string QuizTitle { get { return quizTitle; } 
            set { quizTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizTitle)));
            }
        }

        private string questionTitle = "Question Title";

        public string QuestionTitle { get { return questionTitle; }
            set { questionTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionTitle)));
            }
        }
        
        //private int questionID = 1;
        //public int QuestionID
        //{
        //    get { return questionID; }
        //    set
        //    {
        //        questionID = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionID)));
        //    }
        //}

        private Question selectedQuestion;

        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                //if (selectedQuestion != value)
                //{
                    if (value == null)
                    {
                    return;
                    }
                    IsQuestionSelected = true;
                    selectedQuestion = value;

                    QuestionTitle = selectedQuestion.Title;
                    Answer1content = selectedQuestion.Answers[0].Content ?? "";
                    Answer2content = selectedQuestion.Answers[1].Content ?? "";
                    Answer3content = selectedQuestion.Answers[2].Content ?? "";
                    Answer4content = selectedQuestion.Answers[3].Content ?? "";

                    Answer1Is_correct = selectedQuestion.Answers[0].Is_correct;
                    Answer2Is_correct = selectedQuestion.Answers[1].Is_correct;
                    Answer3Is_correct = selectedQuestion.Answers[2].Is_correct;
                    Answer4Is_correct = selectedQuestion.Answers[3].Is_correct;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedQuestion)));

                //}
            }
        }

        private Quiz selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return selectedQuiz; }
            set
            {
                //if (selectedQuiz != value)
                //{
                    selectedQuiz = value;
                    if(selectedQuiz == null) { return; }
                    IsQuizSelected = true;
                    QuizTitle = selectedQuiz.Title;
                    QuizTimeSpan = selectedQuiz.TimeSpan;
                    Questions = new BindingList<Question>();
                    foreach (Question question in selectedQuiz.Questions)
                    {
                        Questions.Add(question);
                        //selectedQuestion = question;
                    }
                    //IsQuestionSelected = false;
                    //dać foreach do inicjalizatora Questions linijke wyżej, jak nie to jakis sposób zwracania (może funkcja)
                    //    listy/bindinglisty/pojedynczych obiektów (iteratorem?) Questions 

                    //selectedQuestion = Questions

                    //Questions = SelectedQuiz.Questions
                    //Answer1content = SelectedQuiz.Questions[0].Answers[0].Content;
                    //Answer2content = SelectedQuiz.Questions[0].Answers[1].Content;
                    //Answer3content = SelectedQuiz.Questions[0].Answers[2].Content;
                    //Answer4content = SelectedQuiz.Questions[0].Answers[3].Content;

                    //Answer1Is_correct = SelectedQuiz.Questions[0].Answers[0].Is_correct;
                    //Answer2Is_correct = SelectedQuiz.Questions[0].Answers[1].Is_correct;
                    //Answer3Is_correct = SelectedQuiz.Questions[0].Answers[2].Is_correct;
                    //Answer4Is_correct = SelectedQuiz.Questions[0].Answers[3].Is_correct;

                //}
            }
        }



        //private BindingList<Question> questions = new BindingList<Question> {
        //    new Question(){ Id=1, Title="Question" }
        //};
        private BindingList<Question> questions = new BindingList<Question>();

        public BindingList<Question> Questions
        {
            get { return questions; }
            private set
            {
                questions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Questions)));
            }
        }


        //private BindingList<Question.Answer> answers = new BindingList<Question.Answer> {
        //    new Question.Answer(){ Is_correct=false, Content="Answer 1" },
        //    new Question.Answer(){ Is_correct=false, Content="Answer 2" },
        //    new Question.Answer(){ Is_correct=false, Content="Answer 3" },
        //    new Question.Answer(){ Is_correct=false, Content="Answer 4" }
        //};

        ////public BindingList<Question.Answer> Answers { get { return answers; } set { answers = value; } }
        //public BindingList<Question.Answer> Answers {
        //    get { return answers; }
        //    set
        //    {
        //        answers = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers)));
        //    }
        //}

        //TODO: use BindingList like above

        private string answer1content = "Answer 1";
        private string answer2content = "Answer 2";
        private string answer3content = "Answer 3";
        private string answer4content = "Answer 4";

        public string Answer1content
        {
            get { return answer1content; }
            set { answer1content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer1content))); }
        }
        public string Answer2content
        {
            get { return answer2content; }
            set { answer2content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer2content))); }
        }
        public string Answer3content
        {
            get { return answer3content; }
            set { answer3content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer3content))); }
        }
        public string Answer4content
        {
            get { return answer4content; }
            set { answer4content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer4content))); }
        }

        private bool answer1Is_correct = false;
        private bool answer2Is_correct = false;
        private bool answer3Is_correct = false;
        private bool answer4Is_correct = false;

        public bool Answer1Is_correct
        {
            get { return answer1Is_correct; }
            set { answer1Is_correct = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer1Is_correct))); }
        }
        public bool Answer2Is_correct
        {
            get { return answer2Is_correct; }
            set { answer2Is_correct = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer2Is_correct))); }
        }
        public bool Answer3Is_correct
        {
            get { return answer3Is_correct; }
            set { answer3Is_correct = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer3Is_correct))); }
        }
        public bool Answer4Is_correct
        {
            get { return answer4Is_correct; }
            set { answer4Is_correct = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer4Is_correct))); }
        }



        private int quizTimeSpan = 20;
        public int QuizTimeSpan { get => quizTimeSpan; set => quizTimeSpan = value; }


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
        public string Test
        {
            get => test;
            set
            {
                test = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }

        //polecenie 
        private ICommand buttonDeleteQuestion_Click;

        public ICommand ButtonDeleteQuestion_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonDeleteQuestion_Click ?? (buttonDeleteQuestion_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) =>
                    {
                        Questions.Remove(selectedQuestion);
                        selectedQuiz.Questions.Remove(selectedQuestion);
                      
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
            }
        }

        //polecenie 
        private ICommand buttonAddSaveQuestion_Click;

        public ICommand ButtonAddSaveQuestion_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonAddSaveQuestion_Click ?? (buttonAddSaveQuestion_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) =>
                    {
                        Question question = new Question();
                        question.Title = QuestionTitle;
                        //skopiuj elementy z Property BidnigList<Answer> Answers do List<Answer> Question.Answers  
                        question.Answers = new List<Question.Answer>();
                        //question.Answers.AddRange(Answers.Select(i => new Question.Answer()
                        //{
                        //    Is_correct = i.Is_correct,
                        //    Content = i.Content
                        //}));
                        //TODO: loop over like above
                        question.Answers = new List<Question.Answer>
                        {
                            new Question.Answer() { Is_correct = Answer1Is_correct, Content = Answer1content },
                            new Question.Answer() { Is_correct = Answer2Is_correct, Content = Answer2content },
                            new Question.Answer() { Is_correct = Answer3Is_correct, Content = Answer3content },
                            new Question.Answer() { Is_correct = Answer4Is_correct, Content = Answer4content }
                        };
                        Questions.Add(question);
                        //if (SelectedQuiz !=null && SelectedQuiz.Questions.Contains(SelectedQuestion))
                        //{
                        //    SelectedQuiz.Questions.Remove(SelectedQuestion);
                        //}
                        selectedQuiz?.Questions.Add(question);
                        SelectedQuestion = question;
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
            }
        }

        private ICommand buttonSaveQuestion_Click;

        public ICommand ButtonSaveQuestion_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonSaveQuestion_Click ?? (buttonSaveQuestion_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) =>
                    {
                        Question question = SelectedQuestion;
                        question.Title = QuestionTitle;
                        //skopiuj elementy z Property BidnigList<Answer> Answers do List<Answer> Question.Answers  
                        question.Answers = new List<Question.Answer>();
                        //question.Answers.AddRange(Answers.Select(i => new Question.Answer()
                        //{
                        //    Is_correct = i.Is_correct,
                        //    Content = i.Content
                        //}));
                        //TODO: loop over like above
                        question.Answers = new List<Question.Answer>
                        {
                            new Question.Answer() { Is_correct = Answer1Is_correct, Content = Answer1content },
                            new Question.Answer() { Is_correct = Answer2Is_correct, Content = Answer2content },
                            new Question.Answer() { Is_correct = Answer3Is_correct, Content = Answer3content },
                            new Question.Answer() { Is_correct = Answer4Is_correct, Content = Answer4content }
                        };
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
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
                    (p) =>
                    {
                        Quiz currentQuiz = new Quiz();
                        currentQuiz.Title = QuizTitle;
                        currentQuiz.Questions = new List<Question>();
                        //if (Quizes.Contains(selectedQuiz))
                        //{
                        //    currentQuiz.Questions.AddRange(Questions.Select(i => new Question()
                        //    {
                        //        Id = i.Id,
                        //        Answers = i.Answers,
                        //        Title = i.Title,
                        //    }));
                        //}
                        currentQuiz.TimeSpan = QuizTimeSpan;
                        //if (Quizes.Contains(SelectedQuiz))
                        //{
                        //    Quizes.Remove(SelectedQuiz);
                        //}
                        Quizes.Add(currentQuiz);

                        Test = "zmieniony";

                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
            }
        }
        private ICommand buttonAddSaveToDB_Click;

        public ICommand ButtonAddSaveToDB_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonAddSaveToDB_Click ?? (buttonAddSaveToDB_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) =>
                    {
                        int quiz_id = 1;
                        int question_id = 1;
                        int answer_id = 1;
                        DataWrite dataWrite = new DataWrite();
                        dataWrite.ClearDBBeforeWrite();
                        foreach (Quiz quiz in Quizes)
                        {
                            dataWrite.InsertQuiz(quiz_id, quiz.Title, quiz.TimeSpan);
                            
                            foreach (Question question in quiz.Questions)
                            {
                                dataWrite.InsertQuestion(question_id,question.Title ,quiz_id);
                                foreach(Question.Answer answer in question.Answers)
                                {
                                    dataWrite.InsertAnswers(answer_id, answer.Content, answer.Is_correct, question_id);
                                    answer_id++;
                                }
                                question_id++;

                            }
                            quiz_id++;

                        }
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );

            }
        }
        private ICommand buttonLoadFromDB_Click;

        public ICommand ButtonLoadFromDB_Click
        {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return buttonLoadFromDB_Click ?? (buttonLoadFromDB_Click = new BaseClass.RelayCommand(
                    //co wykonuje polecenie
                    (p) =>
                    {
                        DataAccess dataAccess = new DataAccess();
                        Quizes = dataAccess.LoadData(LoadFile.Showdialog());
                        
                    }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );

            }
        }
    }
}
