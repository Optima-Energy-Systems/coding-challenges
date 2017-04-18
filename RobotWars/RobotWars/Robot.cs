using System;

namespace RobotWars {

    public class Robot {
        private readonly Arena arena;

        public Robot
                ( Position startPosition
                , Arena arena ) {
            if( startPosition == null ) throw new ArgumentNullException( nameof( startPosition ) );
            if( arena == null ) throw new ArgumentNullException( nameof( arena ) );


            this.CurrentPosition = startPosition;
            this.arena = arena;
        }

        private const char Left = 'L';
        private const char Right = 'R';
        private const char MovePosition = 'M';

        public Position CurrentPosition { get; private set; }

        public void Move( string movements ) {

            foreach( var movement in movements ) {

                switch( movement ) {
                    case Left: CurrentPosition = CurrentPosition.RotateLeft(); break;
                    case Right: CurrentPosition = CurrentPosition.RotateRight(); break;
                    case MovePosition:
                        var newPosition = CurrentPosition.Move();

                        if( arena.IsWithinArena( newPosition ) ) {
                            CurrentPosition = newPosition;
                        }
                        break;
                }
            }
        }

    }

}
