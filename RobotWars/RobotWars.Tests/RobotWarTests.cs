using Xunit;

namespace RobotWars {

    public class RobotWarTests
    {

        // done: can accept just an arena size

        // done: robot rotates left from north to west        
        // done: robot rotates left from west to south
        // done: robot rotates left from south to east
        // done: robot rotates left from east to north

        // done: robot rotates right from north to east
        // done: robot rotates right from east to south
        // done: robot rotates right from south to west
        // done: robot rotates right from west to north

        // done: robot decrements X if oriented west when moving
        // done: robot increments X if oriented east when moving
        // done: robot decrements Y if oriented south when moving
        // done: robot increments Y if oriented north when moving

        // done: robot trying to move south of the arena results in no change of position
        // done: robot trying to move north of the arena results in no change of position
        // done: robot trying to move east of the arena results in no change of position 
        // done: robot trying to move west of the arena results in no change of position

        // done: robot wars accepts multiple robots

        // Q. How should invalid input be handled?
        //  - arena specification
        //  - robot specification
        //  - robot movement ( missing, malformed )

        // N. Should probably use factories to separate the types from the command format.
        //     Q. How would that work with the movement commands does the same logic apply?


        [Fact]
        public void can_accept_just_an_arena_size() {

            Assert.Equal( string.Empty, robotWar.Play( "5 5" ) );

        }


        [Fact]
        public void robot_rotates_left_from_north_to_west() {

            Assert.Equal( "0 0 W", robotWar.Play( "5 5\n0 0 N\nL" ) );
        }

        [Fact]
        public void robot_rotates_left_from_west_to_south() {

            Assert.Equal( "0 0 S", robotWar.Play( "5 5\n0 0 W\nL" ) );

        }

        [Fact]
        public void robot_rotates_left_from_south_to_east() {

            Assert.Equal( "0 0 E", robotWar.Play( "5 5\n0 0 S\nL" ) );

        }

        [Fact]
        public void robot_rotates_left_from_east_to_north() {

            Assert.Equal( "0 0 N", robotWar.Play( "5 5\n0 0 E\nL" ) );
        }


        [Fact]
        public void robot_rotates_right_from_north_to_east() {

            Assert.Equal( "0 0 E", robotWar.Play( "5 5\n0 0 N\nR" ) );
        }

        [Fact]
        public void robot_rotates_right_from_east_to_south() {

            Assert.Equal( "0 0 S", robotWar.Play( "5 5\n0 0 E\nR" ) );

        }

        [Fact]
        public void robot_rotates_right_from_south_to_west() {

            Assert.Equal( "0 0 W", robotWar.Play( "5 5\n0 0 S\nR" ) );
        }

        [Fact]
        public void robot_rotates_right_from_west_to_norht() {

            Assert.Equal( "0 0 N", robotWar.Play( "5 5\n0 0 W\nR" ) );
        }


        [Fact]
        public void robot_decrements_X_if_oriented_west_when_moving() {

            Assert.Equal( "0 0 W", robotWar.Play( "5 5\n1 0 W\nM" ) );

        }

        [Fact]
        public void robot_increments_X_if_oriented_east_when_moving() {

            Assert.Equal( "1 0 E", robotWar.Play( "5 5\n0 0 E\nM" ) );
        }

        [Fact]
        public void robot_decrements_Y_if_oriented_south_when_moving() {

            Assert.Equal( "0 0 S", robotWar.Play( "5 5\n0 1 S\nM" ) );

        }

        [Fact]
        public void robot_increments_Y_if_oriented_north_when_moving() {

            Assert.Equal( "0 1 N", robotWar.Play( "5 5\n0 0 N\nM" ) );
        }


        [Fact]
        public void robot_trying_to_move_south_of_the_arena_results_in_no_change_of_position() {

            Assert.Equal( "0 0 S", robotWar.Play( "5 5\n0 0 S\nM" ) );

        }

        [Fact]
        public void robot_trying_to_move_north_of_the_arena_results_in_no_change_of_position() {

            Assert.Equal( "0 5 N", robotWar.Play( "5 5\n0 5 N\nM" ) );
        }

        [Fact]
        public void robot_trying_to_move_east_of_the_arena_results_in_no_change_of_position() {

            Assert.Equal( "5 0 E", robotWar.Play( "5 5\n5 0 E\nM" ) );

        }

        [Fact]
        public void robot_trying_to_move_west_of_the_arena_results_in_no_change_of_position() {

            Assert.Equal( "0 0 W", robotWar.Play( "5 5\n0 0 W\nM" ) );
        }


        [Fact]
        public void robot_wars_accepts_multiple_robots() {

            Assert.Equal( $"1 3 N\r\n5 1 E", robotWar.Play( "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM" ));
        }

        private RobotWar robotWar = new RobotWar();

    }

}
