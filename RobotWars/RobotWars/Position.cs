namespace RobotWars {

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
        private const char East = 'E';
        private const char South = 'S';
        private const char West = 'W';

        public int X { get; }
        public int Y { get; }
        public char Orientation { get; set; }

        public override string ToString() {
            return $"{X} {Y} {Orientation}";
        }

        public Position RotateLeft() {

            var newOrientation = Orientation;
            switch( Orientation ) {
                case North: newOrientation = West; break;
                case West: newOrientation = South; break;
                case South: newOrientation = East; break;
                case East: newOrientation = North; break;
            }

            return new Position( X, Y, newOrientation );
        }

        public Position RotateRight() {

            var newOrientation = Orientation;
            switch( Orientation ) {
                case North: newOrientation = East; break;
                case East: newOrientation = South; break;
                case South: newOrientation = West; break;
                case West: newOrientation = North; break;
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

}
