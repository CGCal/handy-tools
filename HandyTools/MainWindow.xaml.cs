using System;
using System.Collections.Generic;
using System.Linq;
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
using Inventor;
using HandyTools.Helper;
using Application = Inventor.Application;


namespace HandyTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Application InventorApplication => connection.InventorApplication;
        private Connection connection;
        //public Application InventorApplication { get; set; }
        private DrawingDocument ActiveDocument { get; set; }
        private Document SelectedDocument { get; set; }
        private SelectSet SelectSet => ActiveDocument.SelectSet;
        private UserInputEvents _userInputEvents;

        public MainWindow()
        {
            InitializeComponent();

            connection = new Connection();
            connection.SetApp();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void HandyTools_Loaded(object sender, RoutedEventArgs e)
        {
        }


        /// <summary>
        /// Drawing Titles Alignment
        /// </summary>
        private void AlignHorizontalButton_Click(object sender, RoutedEventArgs e)
        {

            _userInputEvents = InventorApplication.CommandManager.UserInputEvents;
            ActiveDocument = InventorApplication.ActiveDocument as DrawingDocument;
            if (ActiveDocument == null) { Close(); }

            double posY = 0;

            foreach (var drawingViewLabel in SelectSet.OfType<DrawingViewLabel>())
            {
                if (Math.Abs(posY) < 0.1)
                {
                    posY = Math.Round(drawingViewLabel.Position.Y, 1);
                }
                drawingViewLabel.Position = InventorApplication.TransientGeometry.CreatePoint2d(drawingViewLabel.Position.X, posY);
            }
        }

        private void AlignVerticalButton_Click(object sender, RoutedEventArgs e)
        {
            _userInputEvents = InventorApplication.CommandManager.UserInputEvents;
            ActiveDocument = InventorApplication.ActiveDocument as DrawingDocument;
            if (ActiveDocument == null) { Close(); }

            double posX = 0;

            foreach (var drawingViewLabel in SelectSet.OfType<DrawingViewLabel>())
            {
                if (Math.Abs(posX) < 0.1)
                {
                    posX = Math.Round(drawingViewLabel.Position.X, 1);
                }
                drawingViewLabel.Position = InventorApplication.TransientGeometry.CreatePoint2d(posX, drawingViewLabel.Position.Y);
            }
        }

        private void AlignAutoButton_Click(object sender, RoutedEventArgs e)
        {
            _userInputEvents = InventorApplication.CommandManager.UserInputEvents;
            ActiveDocument = InventorApplication.ActiveDocument as DrawingDocument;
            if (ActiveDocument == null) { Close(); }

            double posX = 0;
            double posY = 0;

            //TODO find out how to select all the drawing view labels and automatically align them.

            foreach (var drawingViewlabel in SelectSet.OfType<DrawingViewLabel>())
            {
                var nothingyet = posX + posY;
            }

        }



        /// <summary>
        /// Balloons Alignment
        /// </summary>

        //TODO make alignment for balloons!!!

    }
}

