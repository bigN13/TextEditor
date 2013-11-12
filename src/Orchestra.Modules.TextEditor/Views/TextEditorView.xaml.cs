// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserView.xaml.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditorModule.Views
{
    using System.Windows.Navigation;
    using Catel.IoC;
    using Catel.Messaging;
    using Orchestra.Modules.TextEditorModule.ViewModels;
    using Orchestra.Views;
    using Catel.MVVM;
    using ICSharpCode.AvalonEdit.Document;
    using System.Text.RegularExpressions;
    using System.Windows.Threading;
    using System;
    using ICSharpCode.AvalonEdit.Folding;
    using System.Windows.Controls;
    using Orchestra.Modules.TextEditorModule.Helpers;
    using ICSharpCode.AvalonEdit.Rendering;
    using System.Windows;
using System.Windows.Media;
    using ICSharpCode.AvalonEdit;
    using ICSharpCode.AvalonEdit.Highlighting;
    using System.Collections.Generic;

    /// <summary>
    /// Interaction logic for BrowserView.xaml.
    /// </summary>
    public partial class TextEditorView : DocumentView
    {
        #region Constants
        private const string UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
        #endregion

        #region Fields
        int prevHighlightedLine = 0;

        List<LineColorizer> ColorizerCollection;

        
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorView"/> class.
        /// </summary>
        public TextEditorView()
        {
            InitializeComponent();

            ColorizerCollection = new List<LineColorizer>();

            #region Folding Init
            //foldingStrategy = new XmlFoldingStrategy();

            //if (foldingManager == null)
            //{
            //    foldingManager = FoldingManager.Install(textEditor.TextArea);
            //}


            DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
            foldingUpdateTimer.Tick += foldingUpdateTimer_Tick;
            foldingUpdateTimer.Start();
           
            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the view model has changed.
        /// </summary>
        protected override void OnViewModelChanged()
        {
            var vm = ViewModel as TextEditorViewModel;
            if (vm != null)
            {
                if (!string.IsNullOrWhiteSpace(vm.Url))
                {
                    OnBrowse(vm.Url);
                }

                var messageMediator = ServiceLocator.Default.ResolveType<IMessageMediator>();
                messageMediator.Register<string>(this, OnBrowse, vm.UrlChangedMessageTag);

                //var messageMediator = ServiceLocator.Default.ResolveType<IMessageMediator>();
                messageMediator.Register<MatchItem>(this, OnParse, "selectedItem");
            }
        }

        private void OnBrowse(string url)
        {
            //webBrowser.Navigate(url, null, null, string.Format("User-Agent: {0}", UserAgent));
        }


 
        private void OnParse(MatchItem SelectedItem)
        {
            if (SelectedItem != null)
            {
                MatchItem m = SelectedItem;

                textEditor.ScrollTo(m.currentLine, 0);

                if (ColorizerCollection.Count > 0 && textEditor.Document.LineCount > 1)
	            {
                    textEditor.TextArea.TextView.LineTransformers.Remove(ColorizerCollection[0]);
                    IHighlighter documentHighlighter = textEditor.TextArea.GetService(typeof(IHighlighter)) as IHighlighter;
                    HighlightedLine result = documentHighlighter.HighlightLine(textEditor.Document.GetLineByNumber(prevHighlightedLine).LineNumber);
                    
                    textEditor.TextArea.TextView.Redraw(result.DocumentLine); // invalidate specific Line
                    ColorizerCollection.Clear();
	            }

                //if (textEditor.Document.LineCount > 1)
                //{
                //    //var line = textEditor.Document.GetLineByNumber(m.currentLine);
                //    //double visualTop = line.Offset-15;
                //    ////textEditor.TextArea.TextView.GetVisualTopByDocumentLine(5);
                //    //textEditor.ScrollToVerticalOffset(visualTop);
                //    //ColorizeAvalonEdit sdfsdf = new ColorizeAvalonEdit()

                //    // Remove previous
                //    if (prevHighlightedLine > 0)
                //    {
                //        ////LineColorizer _prevColorizer = new LineColorizer(prevHighlightedLine);
                //        //textEditor.TextArea.TextView.LineTransformers.Remove(prevColorizer);

                //        //textEditor.TextArea.TextView.LineTransformers.Remove(new LineColorizer(prevHighlightedLine));

                //        //IHighlighter documentHighlighter = textEditor.TextArea.GetService(typeof(IHighlighter)) as IHighlighter;
                //        //HighlightedLine result = documentHighlighter.HighlightLine(textEditor.Document.GetLineByNumber(prevHighlightedLine).LineNumber);

                //        //textEditor.TextArea.TextView.LineTransformers.Remove(result.i);

                        
                //        //prevColorizer
                //        textEditor.TextArea.TextView.Redraw(); // invalidate whole document
                //        //result.DocumentLine.
                //    }
                //}
              
                // Add Colors
                LineColorizer currentHighligtedLine = new LineColorizer(m.currentLine);

                textEditor.TextArea.TextView.LineTransformers.Add(currentHighligtedLine);

                ColorizerCollection.Add(currentHighligtedLine);

                textEditor.TextArea.TextView.Redraw(); // invalidate specific Line
                prevHighlightedLine = m.currentLine;

               

                //if (textEditor.Document.LineCount>1)
                //{
                //    var line = textEditor.Document.GetLineByNumber(m.currentLine);

                //    var col = new OffsetColorizer();

                //    col.StartOffset = line.Offset;
                //    col.EndOffset = line.EndOffset;
                //}
             
             

                //TextViewPosition? start = textEditor.TextArea.TextView.GetPosition(new Point(0, 0) + textEditor.TextArea.TextView.ScrollOffset);
                //TextViewPosition? end = textEditor.TextArea.TextView.GetPosition(new Point(textEditor.TextArea.TextView.ActualWidth, textEditor.TextArea.TextView.ActualHeight) + textEditor.TextArea.TextView.ScrollOffset);

                ////textEditor.TextArea

                //int firstLine = textEditor.TextArea.TextView.GetDocumentLineByVisualTop(textEditor.TextArea.TextView.ScrollOffset.Y).LineNumber;

                //Move to top
                //textEditor.ScrollTo(firstLine - m.currentLine, 0);

                //textEditor.TextArea.TextView.GetDocumentLineByVisualTop(textEditor.TextArea.TextView.ScrollOffset.Y).LineNumber = m.currentLine;

                //textEditor.TextArea.TextView.Redraw();
                //textEditor.TextArea.TextView.sc
                //TextView textView = textEditor.TextArea.TextView;
                //DrawingContext drawingContext;
                //textView.EnsureVisualLines();

                //var line = textEditor.Document.GetLineByNumber(m.currentLine);

                //var segment = new TextSegment { StartOffset = line.Offset, EndOffset = line.EndOffset };

                //foreach (Rect r in BackgroundGeometryBuilder.GetRectsForSegment (textView, segment)) {
                //    drawingContext.DrawRoundedRectangle (
                //        new SolidColorBrush (Color.FromArgb (20, 0xff, 0xff, 0xff)),
                //        new Pen (new SolidColorBrush (Color.FromArgb (30, 0xff, 0xff, 0xff)), 1),
                //        new Rect (r.Location, new Size (textView.ActualWidth, r.Height)),
                //        3, 3
                //    );


                //foreach (Rect r in BackgroundGeometryBuilder.GetRectsForSegment(textView, segment))
                //{
                //    drawingContext.DrawRoundedRectangle(background, border, new Rect(r.Location, new Size(textView.ActualWidth, r.Height)), 3, 3);
                //}

                //for (int i = 1; i < textEditor.LineCount; i++)
                //{
                //    DocumentLine line = textEditor.Document.GetLineByNumber(i);
                //    var content = textEditor.Document.GetText(line);
                //    if (content == m.ToString())
                //    {
                //        textEditor.ScrollTo(i, 0);
                //        return;
                //    }
                //}


                //int textLength = textEditor.Document.TextLength;
                //int linePos = textLength/m.Length;
                //// fetch the end offset of the VisualLine being generated


                //DocumentLine line = textEditor.Document.GetLineByOffset(textEditor.CaretOffset);
                //textEditor.Select(line.Offset, line.Length);
                ////textEditor.Select(m.Index, m.Length);
                //int cur =   textEditor.Text.IndexOf(m.ToString());
                //textEditor.ScrollTo(linePos, 0);
                ////textEditor.ScrollTo(m.Index, 0);

                //TextView textView = this._document.TextArea.TextView;


            }

            //Match m = (Match)SelectedItem;
            //webBrowser.Navigate(url, null, null, string.Format("User-Agent: {0}", UserAgent));
        }

 

        #endregion

        #region Colorize Selected Line


        /// <summary>
        /// Custom LineColorizer
        /// </summary>
        class LineColorizer : DocumentColorizingTransformer
        {
            int lineNumber;

        
            public LineColorizer(int lineNumber)
            {
                if (lineNumber < 1)
                    throw new ArgumentOutOfRangeException("lineNumber", lineNumber, "Line numbers are 1-based.");
                this.lineNumber = lineNumber;
            }

            public int LineNumber
            {
                get { return lineNumber; }
                set
                {
                    if (value < 1)
                        throw new ArgumentOutOfRangeException("value", value, "Line numbers are 1-based.");
                    lineNumber = value;
                }
            }

            protected override void ColorizeLine(ICSharpCode.AvalonEdit.Document.DocumentLine line)
            {
              

                if (!line.IsDeleted && line.LineNumber == lineNumber)
                {
                    int start = line.Offset;
                    int end = line.EndOffset;

                    ChangeLinePart(start, end, ApplyChanges);
                }
            }

            void ApplyChanges(VisualLineElement element)
            {
                // apply changes here
                element.TextRunProperties.SetBackgroundBrush(Brushes.Silver);

                // This lambda gets called once for every VisualLineElement
                // between the specified offsets.
                Typeface tf = element.TextRunProperties.Typeface;
                // Replace the typeface with a modified version of
                // the same typeface
                element.TextRunProperties.SetTypeface(new Typeface(
                    tf.FontFamily,
                    FontStyles.Italic,
                    FontWeights.Bold,
                    tf.Stretch
                ));
            }
        }

           #endregion


        #region Folding
        FoldingManager foldingManager = null;
        AbstractFoldingStrategy foldingStrategy;

        void HighlightingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textEditor.SyntaxHighlighting == null)
            {
                foldingStrategy = null;
            }
            else
            {
                switch (textEditor.SyntaxHighlighting.Name)
                {
                    case "XML":
                        foldingStrategy = new XmlFoldingStrategy();
                        textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        break;
                    case "C#":
                    case "C++":
                    case "PHP":
                    case "Java":
                        textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options);
                        foldingStrategy = new BraceFoldingStrategy();
                        break;
                    default:
                        textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        foldingStrategy = null;
                        break;
                }
            }
            if (foldingStrategy != null)
            {
                if (foldingManager == null)
                    foldingManager = FoldingManager.Install(textEditor.TextArea);
                foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
            }
            else
            {
                if (foldingManager != null)
                {
                    FoldingManager.Uninstall(foldingManager);
                    foldingManager = null;
                }
            }
        }

        void foldingUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (foldingStrategy != null && textEditor.Document != null)
            {
                foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
            }
        }
        #endregion
	
    }

 
 
}