namespace DotFestival.Grains.Interfaces;

public interface IStageGrain : IGrainWithGuidKey
{
    Task PlaySession();
}
