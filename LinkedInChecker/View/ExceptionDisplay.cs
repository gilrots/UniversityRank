using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace LinkedInChecker.View
{
    /// <summary>
    /// Represent Exceptions to display - gets an error message and display
    /// </summary>
    public class ExceptionDisplay
    {
        public ExceptionDisplay(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
