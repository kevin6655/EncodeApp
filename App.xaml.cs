using Prism.Ioc;
using EncodeApp.Views;
using System.Windows;
using System.Threading;
using Prism.Regions;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using EncodeApp.Model;
using EncodeApp.ViewModels;



namespace EncodeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // モデルとインターフェイスの関連付け
            containerRegistry.Register<IDecoding, DecodeModel>();
            containerRegistry.Register<IEncoding, EncodeModel>();
        }

        /// <summary>
        /// モジュールの参照を追加
        /// </summary>
        /// <param name="moduleCatalog">設定するモジュールカタログを表す</param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            //引数で入ってきたカタログにモジュールの参照を追加する。
            //随時追加を行う。

        }


        //リソース確保
        private Mutex mutex = new Mutex(false, "HalationGhostPrismSample");

        /// <summary>
        /// 起動時のイベント
        /// </summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントのデータを格納している</param>
        private void PrismApplication_Startup(object sender, StartupEventArgs e)
        {
            //起動済みの判定
            if (this.mutex.WaitOne(0,false))
            {
                return;
            }
            //↓ 起動していた場合の処理
            // メッセージボックスを表示してAPを終了する

            MessageBox.Show("二重起動はできません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            //終了処理とインスタンス破棄
            this.mutex.Close();
            this.mutex = null;
            //アプリケーション終了
            this.Shutdown();
        }


        /// <summary>
        /// 終了時イベント処理
        /// </summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している引数</param>
        private void PrismApplication_Exit(object sender, ExitEventArgs e)
        {
            //アプリケーション終了時にMutexが解放されていなかったら解放を行う。
            if (this.mutex != null)
            {
                //一時解放
                mutex.ReleaseMutex();
                //完全解放
                mutex.Close();

            }
        }

    }
}
