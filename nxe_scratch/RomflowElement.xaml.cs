using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace nxe_scratch
{
    public partial class RomflowElement : UserControl, IRomflowSelectableUIElement
    {
        public string ElementTitle { get; set; }
        
        private BitmapImage _artworkImage;

        public BitmapImage ArtworkImage
        {
            get { return _artworkImage; }
            set
            {
                _artworkImage = value;
                if (_artworkImage != null)
                {
                    this.ElementImage.Source = _artworkImage;
                }
            }
        }
        public Action ActivateAction { get; set; }



        public RomflowElement()
            : this("", null, null)
        {

        }

        public RomflowElement(string elementTitle, BitmapImage artworkImage, Action activateAction)
        {
            InitializeComponent();
            ElementTitle = elementTitle;
            ArtworkImage = artworkImage;
            ActivateAction = activateAction;
        }
    }
}
