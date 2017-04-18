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
    
}
