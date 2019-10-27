using System;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;
using QuickPython.IDE.ObjectModel;
using QuickPython.IDE.Services;

namespace QuickPython.IDE.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPythonService _pythonService;

        private TextDocument _codeDocument;
        public TextDocument CodeDocument { get => _codeDocument; set => SetField(ref _codeDocument, value); }

        public ICommand StartCommand { get; }


        public MainWindowViewModel(IPythonService pythonService)
        {
            _pythonService = pythonService;

            CodeDocument = new TextDocument(
                "print('Hello, world!')" + Environment.NewLine +
                "input('Press Enter to continue...')"
            );

            StartCommand = new RelayCommand(() => StartAction());
        }

        private void StartAction()
        {
            _pythonService.Execute(CodeDocument.Text);
        }
    }
}
