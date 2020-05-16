using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AppKit;
using Foundation;

namespace AppNapRepro
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        private NSWindow _window;
        private NSObject _activity;
        private DateTime _prevTime;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable |
                        NSWindowStyle.Miniaturizable |
                        NSWindowStyle.Resizable |
                        NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(100, 100, 1024, 768);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            _window.Title = "AppNapRepro";
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            _activity = NSProcessInfo.ProcessInfo.BeginActivity(
                            NSActivityOptions.Background |
                            NSActivityOptions.LatencyCritical,
                            "You charge $3500AUD for this laptop and yet " +
                            "can't provide enough resources for a smooth " +
                            "operation of this app in the background? " +
                            "Eat a dick Apple."
                        );

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var now = DateTime.Now;
                    var now_str = now.ToString("HH:mm:ss.fff");
                    Debug.WriteLine(now_str);
                    var idle_time = now - _prevTime;
                    if (idle_time.TotalMilliseconds > 10000)
                    {
                        Debug.WriteLine("FFSakes Apple!");
                    }
                    _prevTime = now;
                    await Task.Delay(1000);
                }
            });
        }

        public override void WillTerminate(NSNotification notification)
        {
            NSProcessInfo.ProcessInfo.EndActivity(_activity);
            _activity = null;
        }
    }
}
