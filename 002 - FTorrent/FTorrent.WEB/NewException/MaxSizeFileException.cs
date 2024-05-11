namespace FTorrent.WEB.NewException
{
    public class MaxSizeFileException:Exception
    {
        public MaxSizeFileException(string messagem) : base(messagem) { }
    }
}
