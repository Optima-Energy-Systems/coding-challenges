namespace RobotWars {

    public class Arena {
        private readonly int width;
        private readonly int height;

        public Arena
                ( string dimentions ) {

            var fact = dimentions.Split( ' ' );

            width = int.Parse( fact[ 0 ] );
            height = int.Parse( fact[ 1 ] );
        }

        public bool IsWithinArena
                     ( Position position ) {

            if( position.X < 0 || position.X > width ) return false;
            if( position.Y < 0 || position.Y > height ) return false;

            return true;
        }

    }

}
