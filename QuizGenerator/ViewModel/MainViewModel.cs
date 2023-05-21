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


        private string quizTitle;

        public string QuizTitle { get { return quizTitle; } set { quizTitle = value; } }


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
