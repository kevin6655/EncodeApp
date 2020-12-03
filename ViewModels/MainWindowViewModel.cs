using Prism.Mvvm;
using Prism.Events;
using Reactive.Bindings;
using System.Windows.Forms;
using TodoApp.Model;
using Unity;
using System.Reactive.Disposables;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Linq;

namespace TodoApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // Modelのインジェクション　参照みたいな認識
        [Dependency]
        public IDecoding Decoding { get; set; }

        // Modelのインジェクション　参照みたいな認識
        [Dependency]
        public IEncoding Encoding { get; set; }


        // Titleのproperty
        public ReactiveProperty<string> Title { get;  }

        public ReactiveProperty<string> Result { get; set; }
        public ReactiveProperty<string> Input { get; set; } = new ReactiveProperty<string>();

        //Encordイベント
        public ReactiveCommand B64_E_Click { get; set; } = new ReactiveCommand();
        public ReactiveCommand B64_D_Click { get; set; } = new ReactiveCommand();
        public ReactiveCommand U8_E_Click { get; set; } = new ReactiveCommand();
        public ReactiveCommand U8_D_Click { get; set; } = new ReactiveCommand();
        public ReactiveCommand Reset_Click { get; set; } = new ReactiveCommand();

        //property破棄用
        private readonly CompositeDisposable _cd = new CompositeDisposable();



        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            this.Title = new ReactiveProperty<string>("Hello Encode").AddTo(_cd);
            this.Result = new ReactiveProperty<string>().AddTo(_cd);
            B64_E_Click.Subscribe(B64Ecording).AddTo(_cd);
            B64_D_Click.Subscribe(B64Decording).AddTo(_cd);
            U8_E_Click.Subscribe(U8Encording).AddTo(_cd);
            U8_D_Click.Subscribe(U8Decording).AddTo(_cd);
            Reset_Click.Subscribe(StringReset).AddTo(_cd);
        }


        private void B64Decording() 
        {
            Result.Value = Decoding.Base64DecordString(Input.Value);
        }
        private void B64Ecording()
        {
            Result.Value = Encoding.Base64EncordString(Input.Value);
        }
        private void U8Decording()
        {
            Result.Value = Decoding.Utf8DecordString(Input.Value);
        }
        private void U8Encording()
        {
            Result.Value = Encoding.Utf8EncordString(Input.Value);
        }

        private void StringReset()
        {
            Result.Value = "";
            Input.Value = "";
        }

        //インスタンス破棄
        public void Dispose() => this._cd.Dispose();



    }
}
