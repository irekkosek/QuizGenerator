using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;


namespace QuizGenerator.Model
{
    internal static class LoadFile
    {
        public static string Showdialog()
        {
            string fileName = "QuizSolver.db";
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Pliki DB (*.db)|*.db";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Defaulting to 'QuizSolver.db'");
            }
            return fileName;
        }

    }
}
