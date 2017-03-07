namespace RobotWars.Console
{
    internal abstract class ShapedStruct<TStruct>
        where TStruct : struct
    {
	    protected ShapedStruct(TStruct value)
        {
            Value = value;
        }

        public TStruct Value { get; }
    }
}