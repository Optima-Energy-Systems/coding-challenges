using System.Text;

namespace RobotWars {

    // Representation of a single robot war
    public class RobotWar {

        public string Play( string game ) {

            var results = new StringBuilder();
            var commands = game.Split( '\n' );
            var arena = new Arena( commands[ 0 ] );

            for( var i =1; i < commands.Length; i += 2 ) {
                results.AppendLine( executeRobotMovements( arena, commands[ i ], commands[ i + 1 ] ) );
            }

            return results.ToString().Trim();
        }

        private string executeRobotMovements
                        ( Arena arena
                        , string startPosition
                        , string movements ) {

            var robot = new Robot( new Position( startPosition ), arena );
                robot.Move( movements );

            return robot.CurrentPosition.ToString();
        }

    }
    
    public class Robot {
        private Arena arena;

        public Robot
                ( Position startPosition
                , Arena arena ) {

            this.CurrentPosition = startPosition;
            this.arena = arena;
        }

        private const char Left  = 'L';
        private const char Right = 'R';
        private const char MovePosition = 'M';

        public Position CurrentPosition { get; private set; }

        public void Move( string movements ) {

            foreach( var movement in movements ) {

                switch( movement ) {
                    case Left : CurrentPosition = CurrentPosition.RotateLeft(); break;
                    case Right: CurrentPosition = CurrentPosition.RotateRight(); break;
                    case MovePosition :
                        var newPosition = CurrentPosition.Move();

                        if( arena.IsWithinArena( newPosition ) ) {
                            CurrentPosition = newPosition;
                        }
                        break;
                }
            }
        }
    }

    public class Position {

        public Position
                ( string position ) {

            var coordinates = position.Split( ' ' );
            X = int.Parse( coordinates[ 0 ] );
            Y = int.Parse( coordinates[ 1 ] );
            Orientation = coordinates[ 2 ][ 0 ];

        }

        public Position
                ( int x
                , int y 
                , char orientation ) {

            X = x;
            Y = y;
            Orientation = orientation;
        }

        private const char North = 'N';
        private const char East  = 'E';
        private const char South = 'S';
        private const char West  = 'W';

        public int X { get; }
        public int Y { get; }
        public char Orientation { get; set; }

        public override string ToString() {
            return $"{X} {Y} {Orientation}";
        }

        public Position RotateLeft() {

            var newOrientation = Orientation;
            switch( Orientation ) {
                case North : newOrientation = West; break;
                case West  : newOrientation = South; break;
                case South : newOrientation = East; break;
                case East  : newOrientation = North; break;
            }

            return new Position( X, Y, newOrientation );
        }

        public Position RotateRight() {

            var newOrientation = Orientation;
            switch( Orientation ) {
                case North : newOrientation = East; break;
                case East  : newOrientation = South; break;
                case South : newOrientation = West; break;
                case West  : newOrientation = North; break;
            }
            return new Position( X, Y, newOrientation );
        }

        public Position Move() {
            var newX = X + xMovementModifier();
            var newY = Y + yMovementModifier();

            return new Position( newX, newY, Orientation );
        }

        private int xMovementModifier() {
            if( Orientation == West ) return -1;
            if( Orientation == East ) return 1;

            return 0;
        }

        private int yMovementModifier() {
            if( Orientation == South ) return -1;
            if( Orientation == North ) return 1;

            return 0;
        }

    }

    public class Arena {
        private int width;
        private int height;

        public Arena
                ( string dimentions ) {

            var fact = dimentions.Split( ' ' );

            width  = int.Parse( fact[ 0 ] );
            height = int.Parse( fact[ 1 ] );
        }

        public bool IsWithinArena
                     ( Position position ) {

            if( position.X < 0 || position.X > width  ) return false;
            if( position.Y < 0 || position.Y > height ) return false;

            return true;
        }

    }
}
