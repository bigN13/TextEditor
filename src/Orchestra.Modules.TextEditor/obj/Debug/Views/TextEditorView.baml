   M S B A M L   `   `   `  ����W  SOrchestra.Modules.TextEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Orchestra.Modules.TextEditorModule.Helpers*Orchestra.Modules.TextEditorModule.Helpers  5
      =    7Orchestra.Modules.TextEditorModule.Views.TextEditorView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      E ACatel.MVVM, Version=3.7.0.0, Culture=neutral, PublicKeyToken=nullT PCatel.Extensions.Controls, Version=3.7.0.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      J FOrchestra.Shell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullL	 HOrchestra.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/	orchestrahttp://orchestra.codeplex.com  	 5      `
 \ICSharpCode.AvalonEdit, Version=4.3.1.9429, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit 
 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
 5      :d2http://schemas.microsoft.com/expression/blend/2008 
 5	      Gcontrols8clr-namespace:Orchestra.Modules.TextEditorModule.Helpers 
 5
      .��5      &   Catel.Windows.Controls.StackGrid    � RowDefinitions  5      �� 5      $
��Auto �6   �� 5      $	��62* �6    � ColumnDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      ��  � ToolTip$" Go back to the previous page��6&      SmallImageButtonStyle#��[  6M   ��6   �� *GoBack+.��5      �� $N��H/Orchestra.Modules.TextEditor;component/Resources/Images/action_left.png��6   5      �� 5      $! Go forward to the next page��6)   #��[  6O   ��6   �� *	GoForward+.��5       �� $O��I/Orchestra.Modules.TextEditor;component/Resources/Images/action_right.png��6   5!      �� 5#      ��6   �� *Url+.��6!   .  (System.Windows.Interactivity.Interaction   	Behaviors 5$      3  -Catel.Windows.Interactivity.SelectTextOnFocus  5%      <  6Catel.Windows.Interactivity.UpdateBindingOnTextChanged  5&         UpdateDelay$ 0��6'   3  -Catel.Windows.Interactivity.KeyPressToCommand  5'      
   Key$ Enter��6   �  �Catel.Windows.Interactivity.CommandBehaviorBase`1[[System.Windows.FrameworkElement, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Command 6*   �� *UpdateCommand+.��5(      5)      �� 5+      $ Browse��6&   #��[  67   ��6   �� *Browse+.��5,      �� $P��J/Orchestra.Modules.TextEditor;component/Resources/Images/action_browse.png��6   5-      ' 
 !ICSharpCode.AvalonEdit.TextEditor  5/      -   5          Name$ 
textEditor��50      $��4��5/      $
��10pt(�51      $��1��6   $��Consolas)�56         Document 52      �� *
Document+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�   SyntaxHighlighting 53      �� *HighlightDef+   
IsReadOnly 54      �� *
IsReadOnly+   
IsModified 55      ��  �� Path$ IsDirty�$	 TwoWay=�$
 PropertyChanged=�   ShowLineNumbers 57      �� $ ShowLineNumbers�$	 TwoWay=�$
 PropertyChanged=�   WordWrap 58      �� $ WordWrap�$	 TwoWay=�$
 PropertyChanged=�   Text. 5:         Triggers 5;      /  )System.Windows.Interactivity.EventTrigger  5<         	EventName$ TextChanged��6   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5=      0
  *Catel.Windows.Interactivity.EventToCommand
  - 
  &DisableAssociatedObjectOnCannotExecute .  �  �Catel.Windows.Interactivity.CommandTriggerActionBase`1[[System.Windows.FrameworkElement, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Command 5>      �� $ DataContext.UpdateCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType$ catel:UserControlL� �� AncestorLevel$ 1��   CommandParameter 5@      �� $ Document� �� ElementName$ 
textEditor��5A      5B      . 5C       � ContextMenu 5E      �� 5F      .@�5G      m�  m� Command$	 Cut��6   $	��Cut��6   m� 5H      $
 Copy��6   $
��Copy��6   m� 5I      $ Paste��6   $��Paste��6    m� 5J      $ Delete��6   $��Delete��6!   m� 5K      $
 Undo��6   $
��Undo��6   m� 5L      $
 Redo��6   $
��Redo��6   5M      . 5N   (   5O      5Q      5S      