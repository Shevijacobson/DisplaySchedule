using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using ScheduleBL;

namespace ScheduleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            scheduleManBL = new ScheduleBL.ScheduleBL();
            Schedule = scheduleManBL.GetAllSubjects();
            InitializeComponent();
        }
        public List<Subject> Schedule { get; set; }
        ScheduleBL.ScheduleBL scheduleManBL;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numberHours=0;
           string subjectName=TextBoxSubjectName.Text;

            try
            {
                numberHours = int.Parse(TextBoxNumberHours.Text);
            }
            catch
            {
                throw new Exception("wrong text");
            }
            scheduleManBL.InsertNewSubjectAndSave(subjectName, numberHours);
            Schedule = scheduleManBL.GetAllSubjects();
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Schedule)));

        }

        private void SubjectsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
