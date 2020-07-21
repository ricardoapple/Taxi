using Android.App;
using Android.OS;

namespace Taxi.Prism.Droid
{
    [Activity(
        Theme = "@style/Theme.Splash",
        MainLauncher = true,//Sola una MainLauncher puede estar en true.
        NoHistory = true)]//Quita el boton de atras.
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);//Es lo que debe durar un splash
            StartActivity(typeof(MainActivity));
        }
    }
}
