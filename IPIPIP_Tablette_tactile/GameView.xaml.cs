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
using IPIPIP_Tablette_tactile.ObservablePattern;
using IPIPIP_Tablette_tactile.View;

namespace IPIPIP_Tablette_tactile
{
    /// <summary>
    /// Interaction logic for our GameView
    /// </summary>
    public partial class GameView : IObserver
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
            this.GridView = new CGridView();

	        Label label = new Label
	        {
		        Content = "IPIPIP_Tablette Tactile : Mon super Morpion"
	        };
	        MyCanvas.Children.Add(label);

	        this.GameModel = new GameModel();
            this.GameModel.AddObserver(this);

            //It's a reference of the gridView Model
            this.GridView.GridModel = this.GameModel.GridModel;
            
            //We place the grid
            MyCanvas.Children.Add(this.GridView);
            Canvas.SetLeft(this.GridView, GridView.Axis);
            Canvas.SetTop(this.GridView, GridView.Ordinate);
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
        public void Update(ObservablePattern.Observable observable)
        {
        }
        #endregion

        private void OnTouchDown(object sender, TouchEventArgs e)
        {
	        if (e.TouchDevice.GetTagData() != TagData.None)
	        {
	            MessageBox.Show("Un tag est sur la surface");
	        }
        }
    }
}