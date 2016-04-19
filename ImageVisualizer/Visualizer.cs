﻿
using ImageVisualizer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(ImageVisualizer.Visualizer), typeof(VisualizerObjectSource), Target = typeof(System.Drawing.Image), Description = "Image Visualizer")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(ImageVisualizer.Visualizer), typeof(ImageVisualizerObjectSource), Target = typeof(System.Windows.Media.ImageSource), Description = "Image Visualizer")]
//[assembly: System.Diagnostics.DebuggerVisualizer(typeof(ImageVisualizer.Visualizer), typeof(ImageVisualizerObjectSource), Target = typeof(System.Windows.Media.Imaging.BitmapImage), Description = "Image Visualizer")]

namespace ImageVisualizer
{
    public class Visualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
            {
                throw new ArgumentNullException(nameof(windowService), "This debugger does not support modal visualizers.");
            }

            using (var imageForm = new ImageForm(objectProvider))
            {
                windowService.ShowDialog(imageForm);
            }
        }
    }
}