using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using IPIPIP_Tablette_tactile.Model;
using IPIPIP_Tablette_tactile.View;

namespace IPIPIP_Tablette_tactile
{
    /// <summary>
    /// Interaction logic for our GameView
    /// </summary>
    public partial class GameView : ObservablePattern.IObserver
    {
        #region Class attributes
        public CGridView GridView { get; set; }

        public GameModel GameModel { get; set; }
	    #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameView()
        {
            InitializeComponent();
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
            this.init(100, 100, 200, 200, 3, 3);
        }

        /// <summary>
        /// This method prepare the ground :
        /// It place the grid and the number of cell
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="ordinate"></param>
        /// <param name="cellHeight"></param>
        /// <param name="cellWidth"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        protected void init(int axis, int ordinate, int cellHeight, int cellWidth, int rows, int columns)
        {
	        myCanvas.Background = Brushes.Aquamarine;
            this.GridView = new CGridView(cellHeight, cellWidth, ordinate, axis);

	        Label label = new Label
	        {
		        Content = "IPIPIP_Tablette Tactile : Mon super Morpion"
	        };
	        myCanvas.Children.Add(label);
	        myCanvas.Children.Add(this.GridView);

	        this.GameModel = new GameModel(rows, columns);
            this.GameModel.addObserver(this);

            //It's a reference of the gridView Model
            this.GridView.GridModel = this.GameModel.GridModel;
            this.GridView.paint();
            
            //We place the grid
            Canvas.SetLeft(this.GridView, GridView.axis);
            Canvas.SetTop(this.GridView, GridView.ordinate);
            Canvas.SetLeft(label, this.Width/4);
        }

        #region Windows noises
        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }
        #endregion

        #region Observer Part
        public void update(ObservablePattern.IObservable observable)
        {
        }
        #endregion

        private void OnTouchDown(object sender, TouchEventArgs e)
        {
	        if (e.TouchDevice.GetTagData() != TagData.None)
	        {
		        MessageBox.Show("Coucou");
	        }
        }
    }
}