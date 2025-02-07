﻿using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
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

namespace AnnotationSelection_462
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Diagram.Theme = new OfficeTheme();

            Diagram.Nodes = new NodeCollection();
            Diagram.Connectors = new ConnectorCollection();

            NodeViewModel node = new NodeViewModel();
            node.OffsetX = 100;
            node.OffsetY = 100;
            node.UnitHeight = 100;
            node.UnitWidth = 100;
            node.Shape = new RectangleGeometry() { Rect = new Rect(10, 10, 10, 10) };
            node.Annotations = new AnnotationCollection();

            AnnotationEditorViewModel anno = new AnnotationEditorViewModel();
            anno.Content = "Node Annotation";
            anno.Constraints = AnnotationConstraints.Selectable | AnnotationConstraints.Resizable | AnnotationConstraints.Editable | AnnotationConstraints.Rotatable;

            (node.Annotations as AnnotationCollection).Add(anno);

            ConnectorViewModel connector = new ConnectorViewModel();
            connector.SourcePoint = new Point(200, 200);
            connector.TargetPoint = new Point(300, 300);
            connector.Annotations = new AnnotationCollection();

            AnnotationEditorViewModel anno1 = new AnnotationEditorViewModel();
            anno1.Content = "Connector Annotation";
            anno1.Constraints = AnnotationConstraints.Selectable | AnnotationConstraints.Resizable | AnnotationConstraints.Editable | AnnotationConstraints.Rotatable;

            (connector.Annotations as AnnotationCollection).Add(anno1);

            (Diagram.Nodes as NodeCollection).Add(node);
            (Diagram.Connectors as ConnectorCollection).Add(connector);

            (Diagram.Info as IGraphInfo).ItemSelectedEvent += MainWindow_ItemSelectedEvent;
            (Diagram.Info as IGraphInfo).ItemUnSelectedEvent += MainWindow_ItemUnSelectedEvent;
            (Diagram.Info as IGraphInfo).ItemSelectingEvent += MainWindow_ItemSelectingEvent;
            (Diagram.Info as IGraphInfo).ItemUnSelectingEvent += MainWindow_ItemUnSelectingEvent;
            (Diagram.Info as IGraphInfo).AnnotationChanged += MainWindow_AnnotationChanged;

        }

        private void MainWindow_AnnotationChanged(object sender, ChangeEventArgs<object, AnnotationChangedEventArgs> args)
        {
            //When annotation is resized
            if (args.NewValue.AnnotationInteractionState == AnnotationInteractionState.Resized)
            {
                TextBlock.Text += "\n" + "Annotation has been resized!";
            }

            //When annotation is resized
            if (args.NewValue.AnnotationInteractionState == AnnotationInteractionState.Rotated)
            {
                TextBlock.Text += "\n" +"Annotation has been rotated!";
            }

            //When annotation is resized
            if (args.NewValue.AnnotationInteractionState == AnnotationInteractionState.Edited) 
            {
                TextBlock.Text += "\n" +"Annotation has been edited!";
            }
        }

        private void MainWindow_ItemUnSelectingEvent(object sender, DiagramPreviewEventArgs args)
        {
            if (args.Item is IAnnotation)
            {
                TextBlock.Text += "\n" + "Annotation unselecting";
            }
            else if (args.Item is INode)
            {
                TextBlock.Text += "\n" + "Node unselecting";
            }
            else if (args.Item is IConnector)
            {
                TextBlock.Text += "\n" + "Connector unselecting";
            }
        }

        private void MainWindow_ItemSelectingEvent(object sender, DiagramPreviewEventArgs args)
        {
            if (args.Item is IAnnotation)
            {
                TextBlock.Text += "\n" + "Annotation Selecting";
            }
            else if (args.Item is INode)
            {
                TextBlock.Text += "\n" + "Node Selecting";
            }
            else if (args.Item is IConnector)
            {
                TextBlock.Text += "\n" + "Connector Selecting";
            }
        }

        private void MainWindow_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is IAnnotation)
            {
                TextBlock.Text += "\n" + "Annotation is unselected";
            }
            else if (args.Item is INode)
            {
                TextBlock.Text += "\n" + "Node is unselected";
            }
            else if(args.Item is IConnector) 
            {
                TextBlock.Text += "\n" + "Connector is unselected";
            }
        }

        private void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is IAnnotation)
            {
                TextBlock.Text += "\n" + "Annotation is selected";
            }
            else if (args.Item is INode)
            {
                TextBlock.Text += "\n" + "Node is selected";
            }
            else if (args.Item is IConnector)
            {
                TextBlock.Text += "\n" + "Connector is selected";
            }
        }
    }
}
