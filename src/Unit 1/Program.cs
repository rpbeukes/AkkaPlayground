using System;
﻿using Akka.Actor;

namespace WinTail
{
    #region Program
    class Program
    {
        
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            // initialize MyActorSystem
            // YOU NEED TO FILL IN HERE
            MyActorSystem = ActorSystem.Create(Common.STR_MyActorSystem);
           
            // time to make your first actors!
            //YOU NEED TO FILL IN HERE
            var consoleWriterActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()), typeof(ConsoleWriterActor).ToString());
            var tailCoordinatorActor = MyActorSystem.ActorOf(Props.Create(() => new TailCoordinatorActor()), typeof(TailCoordinatorActor).ToString());
            
            var fileValidatorActor = MyActorSystem.ActorOf(Props.Create(() => new FileValidatorActor(consoleWriterActor)), typeof(FileValidatorActor).ToString());
            
            var consoleReaderActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleReaderActor()), typeof(ConsoleReaderActor).ToString());
        
            // tell console reader to begin
            //YOU NEED TO FILL IN HERE
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.AwaitTermination();
        }

       
    }
    #endregion
}
