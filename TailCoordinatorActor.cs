using Akka.Actor;
using System;

namespace WinTail
{
    public class TailCoordinatorActor : UntypedActor
    {
        #region Message types
        /// <summary>
        /// Start tailing the file at user-specified path.
        /// </summary>
        public class StartTail
        {
            public StartTail(string filePath, IActorRef consoleWriterActor)
            {
                FilePath = filePath;
                ReporterActor = consoleWriterActor;
            }

            public string FilePath { get; private set; }

            public IActorRef ReporterActor { get; private set; }
        }

        /// <summary>
        /// Stop tailing the file at user-specified path.
        /// </summary>
        public class StopTail
        {
            public StopTail(string filePath)
            {
                FilePath = filePath;
            }

            public string FilePath { get; private set; }
        }

        #endregion

        protected override void OnReceive(object message)
        {
            if (message is StartTail)
            {
                var msg = message as StartTail;
                // YOU NEED TO FILL IN HERE
                var tailActorChild = Context.ActorOf(Props.Create(() => new TailActor(msg.ReporterActor, msg.FilePath)), typeof(TailActor).ToString());
            }

        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(10, TimeSpan.FromSeconds(30), err =>
            {
                //Maybe we consider ArithmeticException to not be application critical
                //so we just ignore the error and keep going.
                if (err is ArithmeticException) return Directive.Resume;

                //Error that we cannot recover from, stop the failing actor
                else if (err is NotSupportedException) return Directive.Stop;

                //In all other cases, just restart the failing actor
                else return Directive.Restart;
            });
        }
    }
}
