using System.Reactive;
using System.Reactive.Linq;

namespace Dane
{
    internal class DataModel : DataAbstractAPI
    {
        #region private

        private IObservable<EventPattern<BallChangedEventArgs>> observableEvent;
        private List<IDisposable> ballsDispose = new();

        #endregion private

        public DataModel() 
        {
            observableEvent = Observable.FromEventPattern<BallChangedEventArgs>(this, "BallChangedEvent");
        }

        public override void Dispose()
        {
            foreach (Ball b in ballsDispose)
                b.Dispose();
        }

        public override void CreateBall(double x, double y)
        {
            Random r = new();
            Ball newBall = new(x, y);
            ballsDispose.Add(newBall);
            BallChangedEvent?.Invoke(this, new BallChangedEventArgs() { Ball = newBall });
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return observableEvent.Subscribe(x => observer.OnNext(x.EventArgs.Ball),
                                                ex => observer.OnError(ex),
                                                () => observer.OnCompleted());
        }
        #region API

        public override event EventHandler<BallChangedEventArgs>? BallChangedEvent;

        #endregion API
    }
}
